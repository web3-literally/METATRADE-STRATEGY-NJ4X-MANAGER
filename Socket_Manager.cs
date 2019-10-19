using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Quobject.SocketIoClientDotNet.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nj4x_Manager
{
    public class ServerBroker
    {
        public string server_name { get; set; }
        public string server_ip { get; set; }
    }

    public class Plan
    {
        public string name { get; set; }
        public double price { get; set; }
        public double min_lot { get; set; }
        public double max_lot { get; set; }
        public double max_daily_profit { get; set; }
        public double max_daily_loss { get; set; }
        public bool daily_loss_fix { get; set; }
        public double max_total_profit { get; set; }
        public double max_total_loss { get; set; }
        public bool total_loss_fix { get; set; }
        public int max_orders { get; set; }
        public string comment { get; set; }
        public string[] currency_pair { get; set; }
        public bool use_pre_approval { get; set; }
        public double usd_for_pre_approval { get; set; }
        public int validity_period { get; set; }
        public bool outside_control_flag { get; set; }
        public string approval_status { get; set; }
    }

    public class MTAccount
    {
        public string id { get; set; }
        public string account_number { get; set; }
        public string account_password { get; set; }
        public string platform { get; set; }
        public ServerBroker broker { get; set; }
        public Plan plan { get; set; }
        public string server_id { get; set; }
        public string create_date { get; set; }
        public string status { get; set; }

    }

    public class NJ4XServer
    {
        public string id { get; set; }
        public string name { get; set; }
        public string server_ip { get; set; }
        public int server_port { get; set; }
        public int max_terminals { get; set; }
        public int time_sync { get; set; }
        public string status { get; set; }
    }

    public class LogPacket
    {
        public string id { get; set; }
        public DateTime log_datetime { get; set; }
        public string log_data { get; set; }
    }
    class Socket_Manager
    {
        public event ReceivedSyncEASettingWithNj4xEvent SyncEASettingNJ4XCommandReceived;
        public event ReceivedSyncServerSettingWithNj4xEvent SyncServerSettingNJ4XCommandReceived;

        public static Socket_Manager Instance = new Socket_Manager();
        public Socket m_Socket;
        public bool m_bSocketProblem;
        public Socket_Manager()
        {
        }

        public void Initialize()
        {
            m_bSocketProblem = false;
            m_Socket = IO.Socket("http://localhost:3333");
            m_Socket.On(Socket.EVENT_CONNECT, () =>
            {
                Console.WriteLine("*** Connection is Established! ***\n");
                m_Socket.Emit("requestSync","");
            });

            m_Socket.On(Socket.EVENT_DISCONNECT, (msg) =>
            {
                Console.WriteLine("*** Disconnected! ***\n");
                m_bSocketProblem = true;

            });

            m_Socket.On(Socket.EVENT_ERROR, (msg) =>
            {
                Console.WriteLine("*** Error! ***\n" + msg + '\n');
            });

            m_Socket.On("syncEASettingWithNj4x", (msg) =>
            {
                Console.WriteLine("### syncEASettingWithNj4x: \n" + msg + '\n');
                List<MTAccount> listMtAccount = JsonConvert.DeserializeObject<List<MTAccount>>(msg.ToString());
                SyncEASettingNJ4XCommandReceived(listMtAccount);
            });

            m_Socket.On("syncServerSettingWithNj4x", (msg) =>
            {
                Console.WriteLine("### syncServerSettingWithNj4x: \n" + msg + '\n');
                List<NJ4XServer> listNJ4XServer = JsonConvert.DeserializeObject<List<NJ4XServer>>(msg.ToString());
                SyncServerSettingNJ4XCommandReceived(listNJ4XServer);
            });
        }

        public void SendTradingLog(string AccountID, DateTime EventTime, string LogData)
        {

        }
        public void SendAccountLog(string AccountID, DateTime EventTime, string LogData)
        {
            LogPacket packet = new LogPacket();
            packet.id = AccountID;
            packet.log_datetime = EventTime;
            packet.log_data = LogData;

            m_Socket.Emit("accountLog", JsonConvert.SerializeObject(packet));
        }

        public void SendNj4xServerLog(string Nj4xID, DateTime EventTime, string LogData)
        {
            LogPacket packet = new LogPacket();
            packet.id = Nj4xID;
            packet.log_datetime = EventTime;
            packet.log_data = LogData;

            m_Socket.Emit("nj4xLog", JsonConvert.SerializeObject(packet));
        }
    }
}
