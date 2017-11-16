﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telnet
{
    class Program
    {
        public static void R1Config()
        {
            TelnetConnection T1;
            List<String> Result = new List<String>();
            int lineCounter = 1;

            T1 = new TelnetConnection("192.168.10.16", 23);

            T1.CiscoLogin("cisco");
            T1.CiscoEnable("cisco");
            T1.CiscoCommand("conf t");
            T1.CiscoCommand("inter fa0/1");
            T1.CiscoCommand("ip add 192.168.11.17 255.255.255.0");
            T1.CiscoCommand("no shut");
            T1.CiscoCommand("exit");
            T1.CiscoCommand("exit");
            T1.CiscoCommand("write");
            Result = T1.CiscoCommand("Show start");

            Result.ForEach(delegate (String line)
            {
                Console.WriteLine("{0}: {1}", lineCounter, line);
                lineCounter++;
            });
        }
        public static void Sw1Config()
        {
            TelnetConnection T2;
            List<String> Result = new List<String>();
            int lineCounter = 1;

            T2 = new TelnetConnection("192.168.10.24", 23);
            //insert code here
            Result = T2.CiscoCommand("Show start");
            Result.ForEach(delegate (String line)
            {
                Console.WriteLine("{0}: {1}", lineCounter, line);
                lineCounter++;
            });
        }
        public static int r1 = 1;
        public static int sw1 = 2;
        public static int both = 3;
        private static int input;
        static void Main(string[] args)
        {
            Console.WriteLine("What device do you want to config");
            Console.WriteLine("1: R1 192.168.10.16 2: SW1 192.168.10.24 3: Both");
            bool runCommand = true;
            while (runCommand) { }
                try
                {
                    int input = int.Parse(Console.ReadLine());
                } catch
                {
                    Console.WriteLine("that's not an option");
                }
                if ( input == r1)
                {
                    R1Config();
                    Console.WriteLine("Press any key too exit");
                    Console.ReadKey();
                runCommand = false;
                } else if ( input == sw1)
                {
                runCommand = true;
                    Sw1Config();
                    Console.WriteLine("Press any key too exit");
                    Console.ReadKey();
                runCommand = false;
                } else if ( input == both)
                {
                runCommand = true;
                    R1Config();
                    Console.WriteLine("så går vi videre til SW1");
                    Console.WriteLine("press anny key too continue");
                    Console.ReadKey();
                    Sw1Config();
                    Console.WriteLine("Press any key too exit");
                    Console.ReadKey();
                runCommand = false;
                }
        }
    }
}
