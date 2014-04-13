using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace HardDriveScheduler
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] requests = new int[1000];
            Algorithms Handler = new Algorithms();
            Handler.GenerateRequests(ref requests);
            Console.WriteLine("Algo \tSeek Distance\n");
            Console.WriteLine("FCFS \t" + Handler.FCFS(requests).ToString());
            Console.WriteLine("SSTF \t" + Handler.SSTF(requests).ToString());
            Console.WriteLine("SCAN \t" + Handler.SCAN(requests).ToString());
            Console.WriteLine("CSCAN\t" + Handler.CSCAN(requests).ToString());
            Console.WriteLine("LOOK \t" + Handler.LOOK(requests).ToString());
            Console.WriteLine("CLOOK\t" + Handler.CLOOK(requests).ToString());
        }

    }
}
