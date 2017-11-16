using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telnet
{
    class Program
    {
        static void Main(string[] args)
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
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();

        }
    }
}
