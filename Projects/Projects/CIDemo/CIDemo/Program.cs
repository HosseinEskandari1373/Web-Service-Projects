using System;

namespace CIDemo
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Helow Word");

            Console.ReadKey();
        }

        public bool IsPrime(int candidate)
        {
            int x = 2;
            int y = 2;
            int z = x + y;

            if (candidate == z)
            {
                return true;
            }
            else
            {
                return false;
            }
            throw new NotImplementedException("Please create a test first.");
        }
    }
}
