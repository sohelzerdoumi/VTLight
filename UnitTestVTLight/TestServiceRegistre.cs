using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Win32;
using System.Diagnostics;
using VTLight;

namespace UnitTestVTLight
{
    [TestClass]
    public class UnitTestServiceRegistre
    {
        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {
            RegistryKey rkey = Registry.ClassesRoot.OpenSubKey(".exe");
            string extstring = rkey.GetValue("").ToString();
            rkey.Close();
            rkey = Registry.ClassesRoot.OpenSubKey(
                          extstring+"\\shell", true); 
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

        [TestMethod]
        public void GlobalTest()
        {
            Assert.IsFalse(ServiceRegistre.IsInContextMenu());
            ServiceRegistre.AddToContextMenu();
            Assert.IsTrue(ServiceRegistre.IsInContextMenu());
            ServiceRegistre.RemoveFromContextMenu();
            Assert.IsFalse(ServiceRegistre.IsInContextMenu());
        }
    }
}
