using System;
using System.ComponentModel;
using System.Xml.Linq;

namespace TopologicalSort
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string fileName = "edge_list1.txt";  //Make sure that the property copy to output is set as copy always.
            // How to set:
            // 1. Click on edge_list1.txt in the solution explorer.
            // 2. Go to properties (visible in the bottom of solution explorer).
            // 3. Set the property Copy to Outout -> Copy always.

            Graph G= new Graph(fileName);
            G.printGraph();          
            G.TopologicalSort();
            
            Console.WriteLine();
        }
    }
}