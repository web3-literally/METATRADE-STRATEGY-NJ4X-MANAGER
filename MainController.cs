using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Drawing;

namespace Nj4x_Manager
{
    delegate void ReceivedSyncEASettingWithNj4xEvent(List<MTAccount> listMTAccount);
    delegate void ReceivedSyncServerSettingWithNj4xEvent(List<NJ4XServer> listNJ4XServer);

    class MainController
    {
        private static Dashboard _gui;
        public static List<MTAccount> m_listMTAccount { get; set; } = new List<MTAccount>();
        public static List<NJ4XServer> m_listNJ4XServer { get; set; } = new List<NJ4XServer>();
        public static Dashboard Gui
        {
            get { return _gui; }
            set
            {
                _gui = value;

                EventHandler onExit = (sender, args) =>
                {
                    System.Windows.Forms.Application.Exit();
                };

                ReceivedSyncEASettingWithNj4xEvent onSyncEASettingNJ4XCommandReceived = (listMTAccount) =>
                {
                    if (_gui.InvokeRequired)
                    {
                        _gui.Invoke(new MethodInvoker(delegate
                        {
                            _gui.mTAccountBindingSource.DataSource = listMTAccount;
                        }));
                    }
                    m_listMTAccount = listMTAccount;
                    AddMTAccounts();
                };
                ReceivedSyncServerSettingWithNj4xEvent onSyncServerSettingNJ4XCommandReceived = (listNJ4XServer) =>
                {
                    if (_gui.InvokeRequired)
                    {
                        _gui.Invoke(new MethodInvoker(delegate  
                        {
                            _gui.nJ4XServerBindingSource.DataSource = listNJ4XServer;
                        }));
                    }
                    m_listNJ4XServer = listNJ4XServer;

                };
                
                Socket_Manager.Instance.Initialize();
                Socket_Manager.Instance.SyncEASettingNJ4XCommandReceived += onSyncEASettingNJ4XCommandReceived;
                Socket_Manager.Instance.SyncServerSettingNJ4XCommandReceived += onSyncServerSettingNJ4XCommandReceived;

                Thread ConnectCheckThread = new Thread(new ThreadStart(NJ4XServer_Observer.checkConnectState));
                ConnectCheckThread.Start();
            }
        }
        private static Task<TResult> Execute<TResult>(Func<TResult> func)
        {
            return Task.Factory.StartNew(() =>
            {
                var result = default(TResult);
                try
                {
                    result = func();
                }
                catch (Exception ex)
                {
                }

                return result;
            });
        }
        private static Task Execute(Action action)
        {
            return Task.Factory.StartNew(() =>
            {
                try
                {
                    action();
                }
                catch (Exception ex)
                {
                }
            });
        }
        public static void updateGui()
        {
            if (_gui.InvokeRequired)
            {
                _gui.Invoke(new MethodInvoker(delegate
                {
                    _gui.nJ4XServerBindingSource.DataSource = m_listNJ4XServer;
                    _gui.mTAccountBindingSource.DataSource = m_listMTAccount;
                    foreach (DataGridViewRow row in _gui.m_GridViewNJ4XServer.Rows)
                    {
                        if (row.Cells[6].Value != null && row.Cells[6].Value.ToString() == "Connected")
                        {
                            row.DefaultCellStyle.ForeColor = Color.GreenYellow;
                        }
                        else
                        {
                            row.DefaultCellStyle.ForeColor = Color.Red;
                        }
                    }
                }));
            }
        }
        public static void AddMTAccounts()
        {
            if (Socket_Manager.Instance.m_bSocketProblem == false)
            {
                MT_Manager.Instance.disconnectAll();
                for (int i = 0; i < m_listMTAccount.Count(); i++)
                {
                    MT_Manager.Instance.AddTerminalWithAccount(m_listMTAccount[i]);
                }
            }
            Socket_Manager.Instance.m_bSocketProblem = false;
        }
    }
}
