using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using System.Diagnostics;
using System.Globalization;
using System.Text.RegularExpressions;

namespace VTLight
{
    public class VTReport
    {
        public Int32 Positive { get; set; }
        public Int32 Total { get; set; }
        public Dictionary<String, VTReportResult> Results = new Dictionary<String,VTReportResult>();
    }
    public class VTReportResult{
        public String Name {get;set;}
        public String Result {get;set;}
        public DateTime LastUpdate {get;set;}
    }

    public class ServiceVirusTotal
    {
        public static VTReport GetReport(String hash)
        {
            String uri = "https://www.virustotal.com/fr/file/{0}/analysis/";
            HtmlWeb htmlWeb = new HtmlWeb();
            HtmlAgilityPack.HtmlDocument document = htmlWeb.Load( String.Format(uri, hash) );
            VTReport report = new VTReport();

            // Extraction du total et du nombre de positif
            HtmlNode ratioNode =  document.DocumentNode.SelectSingleNode("//*[@id='basic-info']/div/div[1]/table/tbody/tr[3]/td[2]");
            String ratio = ratioNode.InnerText.Replace(" ", String.Empty);
            String[] ratioSplit = ratio.Split('/');
            report.Positive = Int32.Parse(ratioSplit[0]);
            report.Total = Int32.Parse(ratioSplit[1]);

            // Extraction des résultats
            Regex rxClearSpace = new Regex("\\s");
            HtmlNodeCollection antivirusNodes = document.DocumentNode.SelectNodes("//*[@id='antivirus-results']/tbody/tr");
            foreach (HtmlNode avNode in antivirusNodes)
            {
                VTReportResult vtrr = new VTReportResult();

                HtmlNode[] nodes =  avNode.ChildNodes.ToArray<HtmlNode>();
                vtrr.Name = rxClearSpace.Replace( nodes[1].InnerText, String.Empty);
                Debug.WriteLine("name :" + vtrr.Name + ":");

                vtrr.Result = rxClearSpace.Replace( nodes[3].InnerText,  String.Empty);
                Debug.WriteLine("result :" + vtrr.Result + ":");

                string date = rxClearSpace.Replace( nodes[5].InnerText, String.Empty);
                Debug.WriteLine("date :"+date+":");
                vtrr.LastUpdate = DateTime.ParseExact(date, "yyyyMMdd", 
                                  CultureInfo.InvariantCulture);
                report.Results.Add(vtrr.Name,vtrr);
            }
            
            return report;
        }
    }
}
