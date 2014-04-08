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
            GenerateRequests(ref requests);
            Console.WriteLine("FCFS " + FCFS(requests).ToString());
        }

        static void GenerateRequests(ref int[] requests)
        {
            Random temp = new Random(14);

            for (int i = 0; i < 1000; i++)
            {
                requests[i] = temp.Next(4999);
            }
        }
        static int FCFS(int[] requests)
        {
            int counter = 0;
            int lastNumber = 0;

            for (int i = 0; i < 999; i++)
            {
                counter += Math.Abs(requests[i] - lastNumber);
                lastNumber = requests[i];
            }

            return counter;
        }
        static int SSTF(int[] requests)
        {
            //WE DON'T KNOW THE BUFFERSIZE ASK PROF
            int bufferSize = 10;

            //Where the head currently is at
            int lastnumber = 0;

            //how far the head has moved 
            int counter = 0;

            //a temp buffer for the finding the next closest spot
            List<int> tempBuffer = new List<int>();

            //prefill the temp buffer 
            for (int w = 0; w < bufferSize - 1; w++)
            {
                tempBuffer.Add(requests[w]);
            }

            //lets do all the inputs
            for (int i = bufferSize - 1; i < 999; i++)
            {
                int smallest = int.MaxValue - 1;
                int indexOfSmallest = 0;
                for (int j = 0; j < bufferSize; j++)
                {
                    if (smallest > Math.Abs(lastnumber - tempBuffer[j]))
                    {
                        smallest = lastnumber - tempBuffer[j];
                        indexOfSmallest = j;
                    }
                }

                counter += Math.Abs(lastnumber - tempBuffer[indexOfSmallest]);
            }
            return 0;
        }
    }
}
