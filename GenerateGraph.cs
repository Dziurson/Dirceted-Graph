using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafy
{
    public class SetupGraph
    {
        private string _filename;
        private int _vertexCount;
        private int _edgeCount;

        public int EdgeCount
        {
            get { return _edgeCount; }
            private set
            {
                if (value > 0)
                {
                    _edgeCount = value;
                }
                else throw new TooLowValueExcepion(value, 0);
            }
        }

        public string Filename
        {
            get { return _filename; }
            private set
            {
                if (value != null)
                {
                    _filename = value;
                }
                else throw new ArgumentNullException();
               
            }
        }  

        public int VertexCount
        {
            get { return _vertexCount; }
            private set
            {
                if (value > 0)
                {
                    _vertexCount = value;
                }
                else throw new TooLowValueExcepion(value, 0);                
            }
        }

        public SetupGraph(string filename_t, int vertexCount_t, int edgeCount_t)
        {
            Filename = filename_t;
            VertexCount = vertexCount_t;
            EdgeCount = edgeCount_t;
        }

        public SetupGraph()
        {
            Filename = "Test.txt";
            VertexCount = 10;
            EdgeCount = 20;
        }

        public override string ToString()
        {
            return "Klasa do wygenerowania grafu w pliku: " + Filename + "\nLiczba krawedzi: " + EdgeCount + "\nLiczba wierzcholkow: " + VertexCount + "\n";
        }

        public void GenerateFile()
        {
            StreamWriter file = new StreamWriter(Filename);
            int[] _vertexes = new int[VertexCount];
            List<int>[] _neighbours = new List<int>[VertexCount];
            Random random = new Random();
            string alphabet = "abcdefghijklmnopqrstuwxyz";
            for (int i = 0; i < VertexCount; i++)
            {
                _vertexes[i] = i + 1;
                _neighbours[i] = new List<int>();
                if (i != (VertexCount - 1)) _neighbours[i].Add(i + 2);
                else _neighbours[i].Add(random.Next(1, VertexCount));
            }
            int final = EdgeCount - VertexCount;
            int _newneighbour;
            int _randomVertex;
            while (true)
            {
                _newneighbour = random.Next(1,VertexCount+1);
                _randomVertex = random.Next(1, VertexCount);
                if (_randomVertex + 1  == _newneighbour) final--;
                else if (_neighbours[_randomVertex].Contains(_newneighbour)) final--;
                else
                {
                    _neighbours[_randomVertex].Add(_newneighbour);
                    final--;                                  
                }
                if (final == 0) break;
            }             
            for(int i = 0; i < VertexCount; i++)
            {
                foreach(int neighbour in _neighbours[i])
                {
                    file.Write(_vertexes[i] + "," + random.Next(1, 30) + "," + alphabet[random.Next(0,alphabet.Length)] + alphabet[random.Next(0, alphabet.Length)] + alphabet[random.Next(0, alphabet.Length)] + alphabet[random.Next(0, alphabet.Length)] + "," + neighbour + "\n");
                }
            }         
            file.Close();  
        }

        public string ShowFile()
        {
            StreamReader file = new StreamReader(Filename);
            string tmp;
            string ret = null;
            while(true)
            {
                tmp = file.ReadLine();
                if (tmp == null) break;
                else
                {
                    ret += tmp + "\n";
                    Console.WriteLine(tmp);
                }
            }
            file.Close();
            return ret;
        }
    }
}
