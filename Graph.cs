using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TopologicalSort
{
    internal class Graph
    {
        public int nodes, edges;
        public int[,] adj_matrix;
        
        public Graph (string fileName)
        {                     
            
            if (File.Exists(fileName))
            {
                StreamReader sr = new StreamReader(File.OpenRead(fileName));
                //First line in the edge_list file contains number of nodes and edges. 
                if (!sr.EndOfStream)
                {
                    string[] first_line = sr.ReadLine().Split(' ');
                    nodes = Convert.ToInt32(first_line[0]);
                    edges = Convert.ToInt32(first_line[1]);
                    adj_matrix = new int[nodes, edges];
                }
                //Read the edges from second line.
                while (!sr.EndOfStream)
                {
                    int s, d;
                    string[] edge = sr.ReadLine().Split(' ');
                    s = Convert.ToInt32(edge[0]);
                    d = Convert.ToInt32(edge[1]);
                    adj_matrix[s, d] = 1;
                    //adj_matrix[d, s] = 1;
                }
            }
            
        }
        public void printGraph()
        {
            Console.WriteLine("Adjacency Matrix");
            for (int i = 0; i < nodes; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < nodes; j++)
                    Console.Write(adj_matrix[i, j] + " ");
            }
            Console.WriteLine();
            Console.WriteLine();
        }
      
        public void DFT(int v, bool[] visited, Stack<int> stack)
        {
            visited[v] = true;
            
            for (int i = 0; i < nodes; i++)
            {
                if (i == v)
                    continue;
                if (!visited[i] && adj_matrix[v, i] == 1)
                    DFT(i, visited, stack);               
            }
            //Console.WriteLine("element pushed: "+v);
            stack.Push(v);
        }
        public void TopologicalSort()
        {
            Stack<int> stack = new Stack<int>();
            bool[] visited = new bool[nodes];

            for (int i = 0; i < nodes; i++)
            {
                if (!visited[i])
                    DFT(i, visited, stack);
            }

            Console.WriteLine("Topological Sort Order:");           
            foreach (int item in stack.Reverse())
                Console.Write(item+"  ");            
        }
    }
}
