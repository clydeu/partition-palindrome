using System;
using System.Collections.Generic;
using System.Linq;

namespace Partition_Palindrom
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Please pass parameter for processing...");
            }
            else if (args.Length > 1)
            {
                Console.WriteLine("Please pass only 1 parameter for processing...");
            }
            else
            {
                try
                {
                    var partitioner = new PalindromePartitioner();
                    var partitionsList = partitioner.Partition(args[0]);

                    OutputPartitions(partitionsList);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }

            void OutputPartitions(IEnumerable<string> partitions)
            { 
                foreach (var item in partitions)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}
