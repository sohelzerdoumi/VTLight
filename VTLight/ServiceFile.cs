using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace VTLight
{
    class ServiceFile
    {
        public static String GetSha256(String pathfile)
        {
            using (FileStream stream = File.OpenRead(pathfile))
            {
                var sha = new SHA256Managed();
                byte[] checksum = sha.ComputeHash(stream);
                return BitConverter.ToString(checksum).Replace("-", String.Empty).ToLower();
            }
        }
    }
}
