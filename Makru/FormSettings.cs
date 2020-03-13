using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Makru
{
    public partial class FormSettings : Form
    {
        public Settings Settings;

        public FormSettings()
        {
            InitializeComponent();

            Settings = new Settings();
        }

        public FormSettings(Settings settings)
        {
            InitializeComponent();

            Settings = settings;

            nudScreenshootsPerSec.Value = (decimal)settings.ScreenshootsPerSecond;
            cbStartMinimized.Checked = settings.StartProgramMinimzed;
            cbMinimizeOnClose.Checked = settings.MinimizeProgrammOnClose;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Settings.ScreenshootsPerSecond = (float)nudScreenshootsPerSec.Value;
            Settings.StartProgramMinimzed = cbStartMinimized.Checked;
            Settings.MinimizeProgrammOnClose = cbMinimizeOnClose.Checked;

            DialogResult = DialogResult.OK;
        }
    }
}
