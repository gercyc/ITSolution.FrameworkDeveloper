using System;
using System.Drawing;
using System.IO;
using System.Management;
using System.Windows.Forms;

namespace ITSolution.Framework.Util
{
    public class InfoSystemUtil
    {
        public static Size SizeScreen()
        {
            //int c = Screen.PrimaryScreen.BitsPerPixel;

            int w = Screen.PrimaryScreen.Bounds.Width;

            int h = Screen.PrimaryScreen.Bounds.Height;

            return new Size(w, h);
        }
        private static void Testes()
        {
            //https://social.msdn.microsoft.com/Forums/pt-BR/7cb7424e-b4b8-49bd-b8d9-de62d3dedd77/como-exibir-informaes-do-sistema-operacional-?forum=vscsharppt
            OperatingSystem SisOp = Environment.OSVersion;
            var os = SisOp.Platform.ToString();
            var sp = SisOp.ServicePack.ToString();
            var version = SisOp.Version.ToString();

            var user = Environment.UserName;
            var pcName = Environment.MachineName;
            var osv = Environment.OSVersion;
            string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            Console.WriteLine(userName);
            detailMotherBoard();
            detailHardDisk();
        }

        private static void detailMotherBoard()
        {
            //https://code.msdn.microsoft.com/windowsdesktop/Como-Obter-Informaes-da-df7dccc4
            ManagementObjectSearcher s2 = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_Processor");

            foreach (ManagementObject mo in s2.Get())
                Console.WriteLine("Processador: {0}", mo["Name"]);


            ManagementObjectSearcher objMOS = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM  Win32_BaseBoard");

            foreach (ManagementObject objManagemnet in objMOS.Get())
            {
                try
                {
                    Console.WriteLine("======================================================================");
                    Console.WriteLine("                Detalhes da Placa Mãe                                 ");
                    Console.WriteLine("======================================================================");
                    Console.WriteLine("Caption             :" + objManagemnet.GetPropertyValue("Caption").ToString());
                    Console.WriteLine("CreationClassName   :" + objManagemnet.GetPropertyValue("CreationClassName").ToString());
                    Console.WriteLine("Description         :" + objManagemnet.GetPropertyValue("Description").ToString());
                    Console.WriteLine("InstallDate         :" + Convert.ToDateTime(objManagemnet.GetPropertyValue("InstallDate")));
                    //Fabricante
                    Console.WriteLine("Manufacturer        :" + objManagemnet.GetPropertyValue("Manufacturer").ToString());
                    Console.WriteLine("Model               :" + Convert.ToString(objManagemnet.GetPropertyValue("Model")));
                    Console.WriteLine("Name                :" + objManagemnet.GetPropertyValue("Name").ToString());
                    Console.WriteLine("PartNumber          :" + Convert.ToInt32(objManagemnet.GetPropertyValue("PartNumber")));
                    Console.WriteLine("PoweredOn           :" + objManagemnet.GetPropertyValue("PoweredOn").ToString());
                    //Modelo da placa
                    Console.WriteLine("Product             :" + objManagemnet.GetPropertyValue("Product").ToString());
                    Console.WriteLine("SerialNumber        :" + objManagemnet.GetPropertyValue("SerialNumber").ToString());
                    Console.WriteLine("SKU                 :" + Convert.ToString(objManagemnet.GetPropertyValue("SKU")));
                    Console.WriteLine("Status              :" + Convert.ToString(objManagemnet.GetPropertyValue("Status")));
                    Console.WriteLine("Tag                 :" + Convert.ToString(objManagemnet.GetPropertyValue("Tag")));
                    Console.WriteLine("Version             :" + Convert.ToString(objManagemnet.GetPropertyValue("Version")));
                    Console.WriteLine("Weight              :" + Convert.ToString(objManagemnet.GetPropertyValue("Weight")));
                    Console.WriteLine("Height              :" + Convert.ToString(objManagemnet.GetPropertyValue("Height")));
                    Console.WriteLine("PoweredOn           :" + Convert.ToString(objManagemnet.GetPropertyValue("PoweredOn")));
                }
                catch (Exception) { }
            }

        }


        private static void detailHardDisk()
        {
            //https://msdn.microsoft.com/en-us/library/system.io.driveinfo.getdrives(v=vs.110).aspx
            DriveInfo[] allDrives = DriveInfo.GetDrives();

            foreach (DriveInfo d in allDrives)
            {
                Console.WriteLine("Drive {0}", d.Name);
                Console.WriteLine("  Drive type: {0}", d.DriveType);
                if (d.IsReady == true)
                {
                    Console.WriteLine("  Volume label: {0}", d.VolumeLabel);
                    Console.WriteLine("  File system: {0}", d.DriveFormat);
                    Console.WriteLine(
                        "  Available space to current user:{0, 15} bytes",
                        d.AvailableFreeSpace);

                    Console.WriteLine(
                        "  Total available space:          {0, 15} bytes",
                        d.TotalFreeSpace);

                    Console.WriteLine(
                        "  Total size of drive:            {0, 15} bytes ",
                        d.TotalSize);
                }
            }
        }
    }
}
