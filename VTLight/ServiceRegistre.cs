using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VTLight
{
    public class ServiceRegistre
    {
        public static bool IsInContextMenu()
        {
            RegistryKey rkey = Registry.ClassesRoot.OpenSubKey(".exe");
            string extstring = rkey.GetValue("").ToString();
            rkey.Close();
            rkey = Registry.ClassesRoot.OpenSubKey(
                          extstring + "\\shell", true);
            String[] subkeynames = rkey.GetSubKeyNames();
            foreach (string keyname in subkeynames)
            {
                if (keyname.Contains("VTLight"))
                {
                    rkey.Close();
                    return true;
                }
            }
            rkey.Close();
            return false;
        }
        public static bool AddToContextMenu()
        {
            string Extension = ".exe";
            string MenuName = "VTLight";
            string MenuDescription = "Analyse le fichier selectionné avec VTLight";
            string MenuCommand = Path.GetFullPath(Application.ExecutablePath) + " %1";
            bool ret = false;
            RegistryKey rkey = Registry.ClassesRoot.OpenSubKey(Extension);
            if (rkey != null)
            {
                string extstring = rkey.GetValue("").ToString();
                rkey.Close();
                if (extstring != null)
                {
                    if (extstring.Length > 0)
                    {
                        rkey = Registry.ClassesRoot.OpenSubKey(
                          extstring, true);
                        if (rkey != null)
                        {
                            string strkey = "shell\\" + MenuName + "\\command";
                            RegistryKey subky = rkey.CreateSubKey(strkey);
                            if (subky != null)
                            {
                                subky.SetValue("", MenuCommand);
                                subky.Close();
                                subky = rkey.OpenSubKey("shell\\" +
                                  MenuName, true);
                                if (subky != null)
                                {
                                    subky.SetValue("", MenuDescription);
                                    subky.Close();
                                }
                                ret = true;
                            }
                            rkey.Close();
                        }
                    }
                }
            }
            return ret;
        }
        public static void RemoveFromContextMenu()
        {
            RegistryKey rkey = Registry.ClassesRoot.OpenSubKey(".exe");
            string extstring = rkey.GetValue("").ToString();
            rkey.Close();
            rkey = Registry.ClassesRoot.OpenSubKey(
                          extstring + "\\shell", true);
            String[] subkeynames = rkey.GetSubKeyNames();
            foreach (string keyname in subkeynames)
            {
                if (keyname.Contains("VTLight"))
                {
                    rkey.DeleteSubKeyTree("VTLight");
                }
            }
            rkey.Close();
        }

    }
}
