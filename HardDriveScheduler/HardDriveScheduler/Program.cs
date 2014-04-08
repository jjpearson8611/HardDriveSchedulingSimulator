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
            Console.WriteLine("FCFS " + Handler.FCFS(requests).ToString());
            Console.WriteLine("SSTF " + Handler.SSTF(requests).ToString());
            Console.WriteLine("LOOK " + Handler.LOOK(requests).ToString());
            Console.WriteLine("CLOOK " + Handler.CLOOK(requests).ToString());
        }

    }
}
