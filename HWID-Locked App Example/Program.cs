using System;
using System.IO;
using VMProtect;

namespace HWID_Locked_App_Example
{
    class Program
    {
        [BeginUltra]
        static void Main(string[] args)
        {
            string LicenseFile = "./license.DAT";

            if (!File.Exists(LicenseFile))
            {
                Console.WriteLine($"{LicenseFile} is missing!");
                Console.ReadLine();
            }

            SDK.SetSerialNumber(File.ReadAllText(LicenseFile));
            Test();
        }

        // This section of code is protected once applied with VMProtect Ultimate 3.4.0 and cannot be executed without a vaild serial / license file.
        [BeginUltraLockByKey]
        static void Test()
        {
            Console.WriteLine("If you see this then your serial / HWID are vaild.");
            Console.ReadLine();
        }
    }
}
