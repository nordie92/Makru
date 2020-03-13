using Makru.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Makru
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MacroContext());
        }
    }

    public class MacroContext : ApplicationContext
    {
        private FormMacro m_formMacro;
        private NotifyIcon m_trayIcon;

        public MacroContext()
        {
            m_formMacro = new FormMacro();

            // Initialize Tray Icon
            m_trayIcon = new NotifyIcon()
            {
                Icon = Resources.icon,
                ContextMenu = new ContextMenu(new MenuItem[] {
                    new MenuItem("Exit", Exit)
                }),
                Visible = true
            };

            m_trayIcon.DoubleClick += TrayIcon_DoubleClick;
            m_formMacro.FormClosed += M_formMacro_FormClosed;
        }

        private void M_formMacro_FormClosed(object sender, FormClosedEventArgs e)
        {
            m_formMacro.Dispose();
            m_trayIcon.Visible = false;
            Application.Exit();
        }

        private void TrayIcon_DoubleClick(object sender, EventArgs e)
        {
            m_formMacro.Show();
        }

        void Exit(object sender, EventArgs e)
        {
            m_formMacro.Save();
            m_formMacro.Close();
            m_formMacro.Dispose();
            m_trayIcon.Visible = false;
            Application.Exit();
        }
    }
}
