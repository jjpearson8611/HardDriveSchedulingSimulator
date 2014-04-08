using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardDriveScheduler
{
    public class Algorithms
    {
        /// <summary>
        /// Generates 1000 random numbers between 0 and 4999 with same seed
        /// </summary>
        /// <param name="requests">Where to store the randome numbers</param>
        public void GenerateRequests(ref int[] requests)
        {
            Random temp = new Random(14);

            for (int i = 0; i < 1000; i++)
            {
                requests[i] = temp.Next(4999);
            }
        }
        /// <summary>
        /// Uses the FCFS algorithm to determine seek distance
        /// </summary>
        /// <param name="requests">The int array of seek requests</param>
        /// <param name="length">The length of the array default as per prof is 1000</param>
        /// <returns></returns>
        public int FCFS(int[] requests, int length = 1000)
        {
            int counter = 0;
            int lastNumber = 0;

            for (int i = 0; i < length; i++)
            {
                counter += Math.Abs(requests[i] - lastNumber);
                lastNumber = requests[i];
            }

            return counter;
        }

        /// <summary>
        /// Uses the Shortest Seek Time First Algorithm to determine hard drive movement distance totals
        /// </summary>
        /// <param name="requests">Array of ints to use as queue of inputs</param>
        /// <param name="length">How long your int array is default is 1000 as per prof</param>
        /// <returns></returns>
        public int SSTF(int[] requests, int length = 1000)
        {
            //WE DON'T KNOW THE BUFFERSIZE ASK PROF
            int bufferSize = 10;

            //Where the head currently is at
            int lastnumber = 0;

            //how far the head has moved 
            int counter = 0;

            //a temp buffer for the finding the next closest spot
            List<int> tempBuffer = new List<int>();

            //number to hold smallest distance
            int smallest;

            //where is the smallest in the temp buffer
            int indexOfSmallest;

            //prefill the temp buffer 
            for (int w = 0; w < bufferSize - 1; w++)
            {
                tempBuffer.Add(requests[w]);
            }

            //lets do all the inputs
            for (int i = bufferSize - 1; i < length + bufferSize; i++)
            {
                //if there are reads left
                if (i < length)
                {
                    //add another to the tempbuffer
                    tempBuffer.Add(requests[i]);
                }

                //reset temp variables
                smallest = int.MaxValue - 1;
                indexOfSmallest = -1;

                //look to find best choice in buffer
                for (int j = 0; j < tempBuffer.Count; j++)
                {
                    //find the smallest one
                    if (smallest > Math.Abs(lastnumber - tempBuffer[j]))
                    {
                        //update the smallest
                        smallest = Math.Abs(lastnumber - tempBuffer[j]);
                        indexOfSmallest = j;
                    }

                }
                if (indexOfSmallest != -1)
                {
                    //increaes the counter
                    counter += Math.Abs(lastnumber - tempBuffer[indexOfSmallest]);

                    //move the hardrive head
                    lastnumber = tempBuffer[indexOfSmallest];

                    //remove the value we just computed for
                    tempBuffer.Remove(tempBuffer[indexOfSmallest]);
                }
            }

            return counter;
        }


        /// <summary>
        /// Uses the Look Algorithm to determine hard drive movement distance totals
        /// </summary>
        /// <param name="requests">Array of ints to use as queue of inputs</param>
        /// <param name="length">How long your int array is default is 1000 as per prof</param>
        /// <returns></returns>
        public int LOOK(int[] requests, int length = 1000)
        {
            //buffersize will be 10 for now
            int BufferSize = 10;

            //to hold the temp buffer of size 10
            List<int> tempBuffer = new List<int>();

            //going out/up on hardrive or in/down on hard drive
            bool GoingUpWards = true;

            //counts if we have done all the numbers
            int TotalComputed = 0;

            //holds the total distance
            int Distance = 0;

            //counts the number we got from the sweep and adds that many 
            //back into the array
            int NumberRemoved;

            //keeps track of the current position of the read heads
            int CurrentPosition = 0;

            //fills the buffer with the first buffersize of information
            for (int i = 0; i < BufferSize; i++)
            {
                tempBuffer.Add(requests[i]);
            }

            //while we are still looking for info keep going
            while(TotalComputed < length)
            {
                //sort the buffer so we can get them as we go
                tempBuffer.Sort();

                //reset the number removed
                NumberRemoved = 0;

                //are we going up or down
                if (GoingUpWards)
                {
                    for (int w = 0; w < tempBuffer.Count; w++)
                    {
                        if (tempBuffer[w] >= CurrentPosition)
                        {
                            TotalComputed++;
                            NumberRemoved++;
                            Distance += Math.Abs(tempBuffer[w] - CurrentPosition);
                            CurrentPosition = tempBuffer[w];
                            tempBuffer.Remove(tempBuffer[w]);
                            w--;
                        }
                    }

                    //change direction
                    GoingUpWards = false;
                }
                else
                {
                    for (int w = tempBuffer.Count - 1; w >= 0; w--)
                    {
                        if (tempBuffer[w] <= CurrentPosition)
                        {
                            TotalComputed++;
                            NumberRemoved++;
                            Distance += Math.Abs(tempBuffer[w] - CurrentPosition);
                            CurrentPosition = tempBuffer[w];
                            tempBuffer.Remove(tempBuffer[w]);
                        }
                    }
                    //change direction
                    GoingUpWards = true;
                }

                //fill in the space we missed
                for (int j = 0; j < NumberRemoved; j++)
                {
                    if(j + TotalComputed < length)
                    {
                        tempBuffer.Add(requests[j + TotalComputed]);
                    }
                }
            }

            return Distance;
        }

        /// <summary>
        /// Uses the CLook Algorithm to determine hard drive movement distance totals
        /// </summary>
        /// <param name="requests">Array of ints to use as queue of inputs</param>
        /// <param name="length">How long your int array is default is 1000 as per prof</param>
        /// <returns></returns>
        public int CLOOK(int[] requests, int length = 1000)
        {
            //buffersize will be 10 for now
            int BufferSize = 10;

            //to hold the temp buffer of size 10
            List<int> tempBuffer = new List<int>();

            //counts if we have done all the numbers
            int TotalComputed = 0;

            //holds the total distance
            int Distance = 0;

            //counts the number we got from the sweep and adds that many 
            //back into the array
            int NumberRemoved;

            //keeps track of the current position of the read heads
            int CurrentPosition = 0;

            //fills the buffer with the first buffersize of information
            for (int i = 0; i < BufferSize; i++)
            {
                tempBuffer.Add(requests[i]);
            }

            //while we are still looking for info keep going
            while (TotalComputed < length)
            {
                //sort the buffer so we can get them as we go
                tempBuffer.Sort();

                //reset the number removed
                NumberRemoved = 0;
                for (int w = 0; w < tempBuffer.Count; w++)
                {
                    if (tempBuffer[w] >= CurrentPosition)
                    {
                        TotalComputed++;
                        NumberRemoved++;
                        Distance += Math.Abs(tempBuffer[w] - CurrentPosition);
                        CurrentPosition = tempBuffer[w];
                        tempBuffer.Remove(tempBuffer[w]);
                        w--;
                    }
                }
                //fill in the space we missed
                for (int j = 0; j < NumberRemoved; j++)
                {
                    if (j + TotalComputed < length)
                    {
                        tempBuffer.Add(requests[j + TotalComputed]);
                    }
                }

                //if there hasn't been any updates for a while buffer must be full reset the head
                if (NumberRemoved == 0)
                {
                    Distance += CurrentPosition; 
                    CurrentPosition = 0;
                }
            }

            return Distance;
        }
    }
}
