using NDesk.Options;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VTLight
{
    public partial class AnalyseForm : Form
    {
        String filename = null;
        String dirname = null;
        
        public AnalyseForm(String[] args)
        {

            OptionSet options = new OptionSet()
            {
                {"f|file=", "Fichier à analyser", v => filename = v},
                {"d|dir=", "Repertoire à analyser", v => dirname = v},
            };
            List<string> extra;
            try
            {
                extra = options.Parse(args);
            }
            catch (OptionException e)
            {
                Console.Write("greet: ");
                Console.WriteLine(e.Message);
                Console.WriteLine("Try `greet --help' for more information.");
                return;
            }
            InitializeComponent();
        }

        private async void AnalyseForm_Shown(object sender, EventArgs e)
        {
            if( this.filename != null)
                processFile();

        }

        public async void processFile()
        {
            progressBar.Value = 100;
            tvResult.Nodes.Add("filename", filename);
            VTReport report = ServiceVirusTotal.GetReport(ServiceFile.GetSha256(filename));
            if( report.Positive > 0 )
                tvResult.Nodes[0].BackColor = Color.Red;
            else
                tvResult.Nodes[0].BackColor = Color.GreenYellow;

            foreach (var result in report.Results)
            {
                tvResult.Nodes[0].Nodes.Add(result.Key, String.Format("{0} : {1}", result.Key, result.Value.Result));
                if (result.Value.Result.Length > 1)
                    tvResult.Nodes[0].Nodes[result.Key].BackColor = Color.OrangeRed;
            }
            return;
        }
    }
}
