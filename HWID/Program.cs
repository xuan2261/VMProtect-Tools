using System;
using System.IO;
using VMProtect;

namespace HWID
{
    class Program
    {
        static void Main(string[] args)
        {
            // Protect this assembly with VMProtect Ultimate to output a vaild HWID.

            Console.WriteLine(SDK.GetCurrentHWID());
            Console.WriteLine("\n" + "(Output has been saved to 'HWID.txt')");

            File.WriteAllText("HWID.txt", SDK.GetCurrentHWID());

            Console.ReadLine();
        }
    }
}
