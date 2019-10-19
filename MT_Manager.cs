using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using nj4x;
using nj4x.Metatrader;

using System.Collections;
using System.IO;
using System.Reflection;
using System.Threading;
using nj4x.Net;
using NLog;


namespace Nj4x_Manager
{
    class MT_Manager
    {
        public static MT_Manager Instance = new MT_Manager();
        private static List<Strategy> _terminals = new List<Strategy>();

        public static AutoResetEvent CoordinationDoneEvent = new AutoResetEvent(false);
        private MT_Manager()
        {

        }

        public void disconnectAll()
        {
            foreach (var t in _terminals)
            {
                t.Disconnect(true);
            }
            _terminals.Clear();
        }
        
        public static void NewTerminal(object account)
        {
            MTAccount MetaAccount = (MTAccount)account;
            try
            {
                NJ4XServer server = MainController.m_listNJ4XServer.Find(x => x.id == MetaAccount.server_id);

                //---- NJ4X LOG -----
                string strLog = "The OutControl Server (" + server.name + ") Is Executing New Terminal.";
                Socket_Manager.Instance.SendNj4xServerLog(server.id, DateTime.Now, strLog);

                string AproveState = MetaAccount.status;
                string AccountID = MetaAccount.id;
                string ServerHost = server.server_ip;
                int ServerPort = server.server_port;
                string BrokerAddress = MetaAccount.broker.server_ip;
                string AccountNumber = MetaAccount.account_number;
                string AccountPassword = MetaAccount.account_password;
                bool IsMT5 = (MetaAccount.platform == "MT5");

                int magic = 199589;
                int slipage = 50;

                double min_lot = MetaAccount.plan.min_lot;
                double max_lot = MetaAccount.plan.max_lot;
                double max_daily_profit = MetaAccount.plan.max_daily_profit;
                double max_daily_loss = MetaAccount.plan.max_daily_loss;
                bool daily_loss_fix_flag = MetaAccount.plan.daily_loss_fix;
                double max_total_profit = MetaAccount.plan.max_total_profit;
                double max_total_loss = MetaAccount.plan.max_total_loss;
                bool total_loss_fix_flag = MetaAccount.plan.total_loss_fix;
                int max_orders = MetaAccount.plan.max_orders;
                string[] currency_pair = MetaAccount.plan.currency_pair;

                bool FLAG_MAX_DAILY_PROFIT = false;
                bool FLAG_MAX_DAILY_LOSS = false;
                bool FLAG_MAX_TOTAL_PROFIT = false;
                bool FLAG_MAX_TOTAL_LOSS = false;
                                
                var mt4 = new nj4x.Strategy() { IsReconnect = false };
                Console.WriteLine(String.Format("*** Connecting, {0}***", AccountNumber));
                mt4.SetPositionListener(
                    delegate (IPositionInfo initialPositionInfo)
                    {
                        Console.WriteLine("initialPositionInfo=" + initialPositionInfo);
                        CoordinationDoneEvent.Set();
                    },
                    delegate (IPositionInfo info, IPositionChangeInfo changes)
                    {
                        //---------------------- INFO LOG ----------------------
                        foreach (IOrderInfo o in changes.GetNewOrders())
                        {
                            Console.WriteLine("NEW: " + o);
                            Socket_Manager.Instance.SendAccountLog(AccountID, DateTime.Now, "NEW: " + o);
                            if (AproveState != "Aprove")
                            {
                                Console.WriteLine("SORRY, YOUR ACCOUNT IS NOT APROVED! " + mt4.AccountName());
                                Socket_Manager.Instance.SendAccountLog(AccountID, DateTime.Now,
                                    "SORRY, YOUR ACCOUNT IS NOT APROVED! " + mt4.AccountName());
                                mt4.OrderCloseAll();
                                return Task.FromResult(0);
                            }
                            //----------------------------- Check Symbols ------------------------------
                            bool allowed = false;
                            foreach (string strSymbol in currency_pair)
                            {
                                if (strSymbol == o.GetSymbol()) allowed = true;
                            }

                            if (allowed == false)
                            {
                                Console.WriteLine("SORRY, THIS SYMBOL IS NOT ALLOWED! " + mt4.AccountName());
                                Socket_Manager.Instance.SendAccountLog(AccountID, DateTime.Now, 
                                    "SORRY, THIS SYMBOL IS NOT ALLOWED! " + mt4.AccountName());

                                mt4.OrderClose(o.GetTicket(), o.GetLots(), o.GetOpenPrice(), slipage, 0);
                                return Task.FromResult(0);
                            }

                            //--------------------------------- Check Lots ------------------------------
                            if (o.GetLots() < min_lot || o.GetLots() > max_lot)
                            {
                                Console.WriteLine("SORRY, YOU VOLUMN IS OUT OF RANGE! " + mt4.AccountName());
                                Socket_Manager.Instance.SendAccountLog(AccountID, DateTime.Now,
                                    "SORRY, YOU VOLUMN IS OUT OF RANGE! " + mt4.AccountName());
                                
                                mt4.OrderClose(o.GetTicket(), o.GetLots(), o.GetOpenPrice(), slipage, 0);
                                return Task.FromResult(0);
                            }

                            double DailyLots = 0;
                            for (int v = 0; v < mt4.OrdersTotal(); ++v)
                            {
                                IOrderInfo orderInfo = mt4.OrderGet(v, SelectionType.SELECT_BY_POS, SelectionPool.MODE_TRADES);
                                if (orderInfo != null)
                                {
                                    DailyLots += orderInfo.GetLots();
                                }
                            }

                            if (o.GetLots() < min_lot || o.GetLots() > max_lot)
                            {
                                Console.WriteLine("SORRY, YOU LOTS IS OUT OF MAX DAILY LOTS RANGE! " + mt4.AccountName());
                                Socket_Manager.Instance.SendAccountLog(AccountID, DateTime.Now,
                                    "SORRY, YOU LOTS IS OUT OF MAX DAILY LOTS RANGE! " + mt4.AccountName());

                                mt4.OrderClose(o.GetTicket(), o.GetLots(), o.GetOpenPrice(), slipage, 0);
                                return Task.FromResult(0);
                            }
                        }
                        foreach (IOrderInfo o in changes.GetModifiedOrders())
                        {
                            Console.WriteLine("MODIFIED: " + o);
                            Socket_Manager.Instance.SendAccountLog(AccountID, DateTime.Now,
                                    "MODIFIED: " + o);
                            if (AproveState != "Aprove")
                            {
                                Console.WriteLine("SORRY, YOUR ACCOUNT IS NOT APROVED! " + mt4.AccountName());
                                Socket_Manager.Instance.SendAccountLog(AccountID, DateTime.Now,
                                    "SORRY, YOUR ACCOUNT IS NOT APROVED! " + mt4.AccountName());
                                mt4.OrderCloseAll();
                                return Task.FromResult(0);
                            }
                            //--------------------------------- Check Lots ------------------------------
                            if (o.GetLots() < min_lot || o.GetLots() > max_lot)
                            {
                                Console.WriteLine("SORRY, YOU VOLUMN IS OUT OF RANGE! " + mt4.AccountName());
                                Socket_Manager.Instance.SendAccountLog(AccountID, DateTime.Now,
                                    "SORRY, YOU VOLUMN IS OUT OF RANGE! " + mt4.AccountName());

                                mt4.OrderClose(o.GetTicket(), o.GetLots(), o.GetOpenPrice(), slipage, 0);
                                return Task.FromResult(0);
                            }

                            double DailyLots = 0;
                            for (int v = 0; v < mt4.OrdersTotal(); ++v)
                            {
                                IOrderInfo orderInfo = mt4.OrderGet(v, SelectionType.SELECT_BY_POS, SelectionPool.MODE_TRADES);
                                if (orderInfo != null)
                                {
                                    DailyLots += orderInfo.GetLots();
                                }
                            }

                            if (o.GetLots() < min_lot || o.GetLots() > max_lot)
                            {
                                Console.WriteLine("SORRY, YOU LOTS IS OUT OF MAX DAILY LOTS RANGE! " + mt4.AccountName());
                                Socket_Manager.Instance.SendAccountLog(AccountID, DateTime.Now,
                                    "SORRY, YOU LOTS IS OUT OF MAX DAILY LOTS RANGE! " + mt4.AccountName());

                                mt4.OrderClose(o.GetTicket(), o.GetLots(), o.GetOpenPrice(), slipage, 0);
                                return Task.FromResult(0);
                            }
                        }
                        foreach (IOrderInfo o in changes.GetClosedOrders())
                        {
                            Console.WriteLine("CLOSED: " + o);
                            Socket_Manager.Instance.SendAccountLog(AccountID, DateTime.Now,
                                    "CLOSED: " + o);
                        }
                        foreach (IOrderInfo o in changes.GetDeletedOrders())
                        {
                            Console.WriteLine("DELETED: " + o);
                            Socket_Manager.Instance.SendAccountLog(AccountID, DateTime.Now,
                                    "DELETED: " + o);
                        }

                        if (AproveState != "Aprove")
                        {
                            Console.WriteLine("SORRY, YOUR ACCOUNT IS NOT APROVED! " + mt4.AccountName());
                            Socket_Manager.Instance.SendAccountLog(AccountID, DateTime.Now,
                                "SORRY, YOUR ACCOUNT IS NOT APROVED! " + mt4.AccountName());
                            mt4.OrderCloseAll();
                            return Task.FromResult(0);
                        }

                        //------------------------------- Calculate Profit Information ----------------------------
                        double TotalMaxBalance = 0;
                        double DailyMaxBalance = 0;
                        double TotalProfit = 0;
                        double DailyProfit = 0;

                        double CurBalance = mt4.AccountBalance();
                        TotalMaxBalance = CurBalance;
                        DailyMaxBalance = CurBalance;

                        int total = mt4.OrdersHistoryTotal();
                        for (int v = 0; v < total; ++v)
                        {
                            IOrderInfo orderInfo = mt4.OrderGet(v, SelectionType.SELECT_BY_POS, SelectionPool.MODE_HISTORY);
                            if (orderInfo != null)
                            {
                                if (orderInfo.GetTradeOperation() == TradeOperation.OP_BUY || orderInfo.GetTradeOperation() == TradeOperation.OP_SELL)
                                {
                                    if (CurBalance > TotalMaxBalance || TotalMaxBalance == 0) TotalMaxBalance = CurBalance;
                                    CurBalance = CurBalance - orderInfo.GetProfit();
                                    TotalProfit += orderInfo.GetProfit();

                                    if (orderInfo.GetCloseTime() >= mt4.iTime(orderInfo.GetSymbol(),Timeframe.PERIOD_D1,0))
                                    {
                                        if (CurBalance > DailyMaxBalance || DailyMaxBalance == 0) DailyMaxBalance = CurBalance;
                                        DailyProfit += orderInfo.GetProfit();
                                    }
                                }
                            }
                        }

                        Console.WriteLine("TotalMaxBalance: " + TotalMaxBalance.ToString());
                        Console.WriteLine("DailyMaxBalance: " + DailyMaxBalance.ToString());
                        Console.WriteLine("TotalProfit: " + TotalProfit.ToString());
                        Console.WriteLine("DailyProfit: " + DailyProfit.ToString());
                        if (DailyProfit >= max_daily_profit)
                        {
                            mt4.OrderCloseAll();
                            Console.WriteLine("CONGRATS, YOU REACHED THE MAX PROFIT TODAY! "+ mt4.AccountName());
                            Socket_Manager.Instance.SendAccountLog(AccountID, DateTime.Now,
                                    "CONGRATS, YOU REACHED THE MAX PROFIT TODAY! " + mt4.AccountName());

                            FLAG_MAX_DAILY_PROFIT = true;
                            return Task.FromResult(0);
                        }
                        else
                        {
                            FLAG_MAX_DAILY_PROFIT = false;
                        }



                        //CheckTotalProfit
                        if (TotalProfit >= max_total_profit)
                        {
                            mt4.OrderCloseAll();
                            Console.WriteLine("CONGRATS, YOU REACHED THE MAX TOTAL PROFIT! " + mt4.AccountName());
                            Socket_Manager.Instance.SendAccountLog(AccountID, DateTime.Now,
                                    "CONGRATS, YOU REACHED THE MAX TOTAL PROFIT! " + mt4.AccountName());

                            FLAG_MAX_TOTAL_PROFIT = true;
                            return Task.FromResult(0);
                        }
                        else
                        {
                            FLAG_MAX_TOTAL_PROFIT = false;
                        }


                        //Check Fix Flag
                        CurBalance = mt4.AccountBalance();
                        if (daily_loss_fix_flag == false)
                        {
                            DailyProfit = CurBalance - DailyMaxBalance;
                        }
                        if (total_loss_fix_flag == false)
                        {
                            TotalProfit = CurBalance - TotalMaxBalance;
                        }


                        if (DailyProfit <= max_daily_loss)
                        {
                            mt4.OrderCloseAll();
                            Console.WriteLine("SORRY, YOU REACHED THE MAX LOSS TODAY! " + mt4.AccountName());
                            Socket_Manager.Instance.SendAccountLog(AccountID, DateTime.Now,
                                    "SORRY, YOU REACHED THE MAX LOSS TODAY! " + mt4.AccountName());

                            FLAG_MAX_DAILY_LOSS = true;
                            return Task.FromResult(0);
                        }
                        else
                        {
                            FLAG_MAX_DAILY_LOSS = false;
                        }


                        if (TotalProfit <= max_total_loss)
                        {
                            mt4.OrderCloseAll();
                            Console.WriteLine("SORRY, YOU REACHED THE MAX TOTAL LOSS! " + mt4.AccountName());
                            Socket_Manager.Instance.SendAccountLog(AccountID, DateTime.Now,
                                    "SORRY, YOU REACHED THE MAX TOTAL LOSS! " + mt4.AccountName());

                            FLAG_MAX_TOTAL_LOSS = true;
                            return Task.FromResult(0);
                        }
                        else
                        {
                            FLAG_MAX_TOTAL_LOSS = false;
                        }


                        return Task.FromResult(0);
                    }
                );
                

                mt4.Connect(ServerHost, ServerPort,
                        new Broker(IsMT5 ? $"5*{BrokerAddress}" : BrokerAddress),
                        AccountNumber,
                        AccountPassword);

                _terminals.Add(mt4);

                //---- NJ4X LOG -----
                Console.WriteLine(String.Format("*** Connected, {0}***", mt4.GetVersion()));
                strLog = "The OutControl Server (" + server.name + ") Successed To Add New Terminal.";
                Socket_Manager.Instance.SendNj4xServerLog(server.id, DateTime.Now, strLog);

                using (mt4)
                {
                    int total = mt4.OrdersHistoryTotal();
                    for (int v = 0; v < Math.Min(10, total); ++v)
                    {
                        IOrderInfo orderInfo = mt4.OrderGet(v, SelectionType.SELECT_BY_POS, SelectionPool.MODE_HISTORY);
                        if (orderInfo != null)
                        {
                            Console.WriteLine(
                                String.Format("Historical order #{0}, P/L={1}, type={2}, symbol={3}, comments={4}",
                                                orderInfo.GetTicket(),
                                                orderInfo.GetProfit(),
                                                orderInfo.GetTradeOperation(),
                                                orderInfo.GetSymbol(),
                                                orderInfo.GetComment()
                                    ));
                        }
                    }
                    //
                    total = mt4.OrdersTotal();
                    for (int v = 0; v < Math.Min(10, total); ++v)
                    {
                        IOrderInfo orderInfo = mt4.OrderGet(v, SelectionType.SELECT_BY_POS, SelectionPool.MODE_TRADES);
                        if (orderInfo != null)
                        {
                            Console.WriteLine(
                                String.Format("LIVE order #{0}, P/L={1}, type={2}, symbol={3}, comments={4}",
                                                orderInfo.GetTicket(),
                                                orderInfo.GetProfit(),
                                                orderInfo.GetTradeOperation(),
                                                orderInfo.GetSymbol(),
                                                orderInfo.GetComment()
                                    ));
                        }
                    }
                    while (true)
                    {
                        Thread.Sleep(10);
                    }
                }
                
            }
            catch
            {
                Console.WriteLine("*** Server is not connected or Your Account is not assigned Server! *** " + MetaAccount.account_number);
            }
        }
        public void AddTerminalWithAccount(MTAccount account)
        {
            Thread ChildThread = new Thread(new ParameterizedThreadStart(NewTerminal));
            ChildThread.Start(account);
        }
    }
}
