using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafy
{
    public class A
    {
        protected A() { }
        public void foo()
        {

        }

    }    
    class Program
    {
        static void Main(string[] args)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            SetupGraph g1 = new SetupGraph("Test.txt", 1000, 5000);
           
            g1.GenerateFile();
            watch.Stop();
            Console.WriteLine(watch.Elapsed);
           
            watch.Start();
            Graph g = new Graph("Test.txt");
            watch.Stop();
            Console.WriteLine(watch.Elapsed);
            Console.Read();

            g.colour();
            g.showGraph();
            
            Console.Read();
            Console.Read();
            
        }
    }
}
