using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VTLight
{
    public partial class OptionsForm : Form
    {
        public OptionsForm()
        {
            InitializeComponent();
            cbAddToExplorator.Checked = ServiceRegistre.IsInContextMenu();
        }

        private void cbAddToExplorator_CheckedChanged(object sender, EventArgs e)
        {
            if (cbAddToExplorator.Checked)
            {
                ServiceRegistre.AddToContextMenu();
            }
            else
            {
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
