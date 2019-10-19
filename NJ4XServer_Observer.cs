using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using nj4x.Net;
using System.Windows.Forms;

namespace Nj4x_Manager
{
    class NJ4XServer_Observer
    {
        public static void checkConnectState()
        {
            for (int i = 0; i < MainController.m_listNJ4XServer.Count(); i++)
            {
                Socket_Manager.Instance.SendNj4xServerLog(MainController.m_listNJ4XServer[i].id, 
                    DateTime.Now, "OutControl Server("+ MainController.m_listNJ4XServer[i].name +") Started!");
            }
            while (true)
            {
                for (int i = 0; i < MainController.m_listNJ4XServer.Count(); i++)
                {
                    string ServerHost = MainController.m_listNJ4XServer[i].server_ip;
                    int ServerPort = MainController.m_listNJ4XServer[i].server_port;
                    ulong tsBoxid = 0;
                    if (ServerPort > 0 && !String.IsNullOrEmpty(ServerHost))
                    {
                        try
                        {
                            tsBoxid = TerminalClient.GetBoxID(ServerHost, ServerPort);
                            if (tsBoxid > 0)
                            {
                                if (MainController.m_listNJ4XServer[i].status == "Disconnected")
                                {
                                    string strLog = "The OutControl Server (" + MainController.m_listNJ4XServer[i].name + ") Is Connected!";
                                    Socket_Manager.Instance.SendNj4xServerLog(MainController.m_listNJ4XServer[i].id, DateTime.Now, strLog);
                                }

                                MainController.m_listNJ4XServer[i].status = "Connected";
                            }
                            else
                            {
                                if (MainController.m_listNJ4XServer[i].status == "Connected")
                                {
                                    string strLog = "The OutControl Server (" + MainController.m_listNJ4XServer[i].name + ") Is Disconnected!";
                                    Socket_Manager.Instance.SendNj4xServerLog(MainController.m_listNJ4XServer[i].id, DateTime.Now, strLog);
                                }

                                MainController.m_listNJ4XServer[i].status = "Disconnected";
                            }
                        }
                        catch (Exception e)
                        {
                            if (MainController.m_listNJ4XServer[i].status == "Connected")
                            {
                                string strLog = "The OutControl Server (" + MainController.m_listNJ4XServer[i].name + ") Is Disconnected!";
                                Socket_Manager.Instance.SendNj4xServerLog(MainController.m_listNJ4XServer[i].id, DateTime.Now, strLog);
                            }

                            MainController.m_listNJ4XServer[i].status = "Disconnected";
                        }
                    }
                }
                MainController.updateGui();
                Thread.Sleep(1000);   
            }
        }
    }
}
