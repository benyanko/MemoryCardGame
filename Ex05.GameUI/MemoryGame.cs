using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ex05.GameUI
{
    public class MemoryGame
    {
        public static void Main()
        {
            Start();
        }

        private static void Start()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            SettingsForm settingsForm = new SettingsForm();
            settingsForm.ShowDialog();
        }
    }
}
