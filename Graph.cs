using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafy
{
    public class Graph
    {
        private int _graphSize;        
        private Vertex[] vertexes_t;
                
        public int GraphSize
        {
            get { return _graphSize; }
            set { _graphSize = value; }
        }

        public Graph(string filename)
        {
            GraphSize = 0;
            vertexes_t = new Vertex[1];
            StreamReader reader = new StreamReader(filename);
            string line = reader.ReadLine();
            string[] parts = new string[4];
            while(line!= null)
            {
                parts = line.Split(',');

                addEdge(new Edge(new Vertex(Int32.Parse(parts[0])), new Vertex(Int32.Parse(parts[3])),parts[2], Int32.Parse(parts[1])));
                line = reader.ReadLine();                
            }
            reader.Close();
        }

        public bool addVertex(Vertex v)
        {
            if (vertexes_t.Length <= v.Number)
            {
                Array.Resize(ref vertexes_t, v.Number + 1);
                vertexes_t[v.Number] = v;
                return true;
            }
            else if (vertexes_t[v.Number] != null)
            {
                Console.WriteLine("Vertex exist.");
                return false;
            }
            else
            {
                vertexes_t[v.Number] = v;
                return true;
            }
        }

        public bool addEdge(Edge e)
        {
            if (e.From.Number + 1 > vertexes_t.Length)
            {
                Array.Resize(ref vertexes_t, e.From.Number + 1);
                vertexes_t[e.From.Number] = e.From;
                if (e.To.Number + 1 >= vertexes_t.Length)
                {
                    Array.Resize(ref vertexes_t, e.To.Number + 1);
                    vertexes_t[e.To.Number] = e.To;
                }
            }
            else if (e.To.Number + 1 > vertexes_t.Length)
            {
                Array.Resize(ref vertexes_t, e.To.Number + 1);
                vertexes_t[e.To.Number] = e.To;
                if (e.From.Number + 1 >= vertexes_t.Length + 1)
                {
                    Array.Resize(ref vertexes_t, e.From.Number);
                    vertexes_t[e.From.Number] = e.From;
                }
            }
            if (vertexes_t[e.From.Number] == null)
            {
                vertexes_t[e.From.Number] = e.From;
                if (vertexes_t[e.To.Number] == null) vertexes_t[e.To.Number] = e.To;
                vertexes_t[e.From.Number].addNeighbour(vertexes_t[e.To.Number], e.Weight, e.Label);
                return true;
            }           
            if (vertexes_t[e.To.Number] == null)
            {
                vertexes_t[e.To.Number] = e.To;
            }               
            foreach(Edge e_t in vertexes_t[e.From.Number].getNeighbours())
            {
                if (e_t.To == e.To) return false;
            }
            vertexes_t[e.From.Number].addNeighbour(vertexes_t[e.To.Number], e.Weight, e.Label);
            GraphSize++;
            return true;              
        }
       
        public void showGraph()
        {
            foreach(Vertex v in vertexes_t)
            {
                Console.WriteLine(v);
            }
        }

        public void colour()
        {
            bool first = true;
            foreach (Vertex v in vertexes_t)
            {
                if (v != null && first)
                {
                    v.colour = 1;
                    first = false;
                }
                else if(v!= null)
                {
                    if (v.colour == 0)
                    {
                        List<int> colours_neighbours = new List<int>();
                        foreach (Edge e in v.getNeighbours())
                        {
                            if (!colours_neighbours.Contains(e.To.colour))
                            {
                                colours_neighbours.Add(e.To.colour);
                            }
                        }
                        int colour_t = 1;
                        while (true)
                        {
                            if (colours_neighbours.Contains(colour_t))
                            {
                                colour_t++;
                                continue;
                            }
                            else
                            {
                                v.colour = colour_t;
                                break;
                            }
                        }
                    }                   
                }             
            }
        }
    }
}
