using System;
using System.IO;
using MadMilkman.Ini;
using VMProtect.KeyGen;

namespace LicenseGen
{
    class Program
    {
        static void Main(string[] args)
        {
            // Using MadMilkman.Ini for parsing your configuration file.
            IniFile LocalINI = new IniFile();
            string ConfigurationFile = "./Config.ini";

            if (!File.Exists(ConfigurationFile))
            {
                Console.WriteLine($"{ConfigurationFile} is missing!");
                Console.ReadLine();
            }
            else
            {
                LocalINI.Load(ConfigurationFile);

                // VMProtect Ultimate > Export Key Pair > Parameters for KeyGen.NET/PayPro Global.
                string RSA = LocalINI.Sections[0].Keys[0].Value;
                // Output a license file with a valid (HWID-Locked) serial.
                string Output = LocalINI.Sections[0].Keys[1].Value;

                Console.WriteLine("Enter customers HWID...");

                try
                {
                    Generator g = new Generator(RSA)
                    {
                        HardwareID = Console.ReadLine()
                    };

                    string serial = g.Generate();
                    File.WriteAllText(Output, serial);

                    Console.WriteLine("\n" + $"Successfully saved {Output}");
                    Console.ReadLine();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\n" + "Error: {0}", ex);
                    Console.ReadLine();
                }
            }
        }
    }
}
