using System;
using System.Collections.Generic;

namespace Grafy
{
    public class Vertex
    {
        private int _number;
        private List<Edge> _neighbours = new List<Edge>();
        public int colour = 0;

        public int Number
        {
            get { return _number; }
            private set
            {
                if (value > 0)
                {
                    _number = value;
                }
                else throw new TooLowValueExcepion(value, 0);
            }
        }

        public Vertex(int number_t)
        {
            Number = number_t;
        }

        public Vertex(int number_t, int weight_t, string label_t, Vertex to)
        {
            Number = number_t;
            _neighbours.Add(new Edge(this, to, label_t, weight_t));              
        }

        public List<Edge> getNeighbours()
        {
            return _neighbours;
        }

        public bool addNeighbour(Vertex v, int weight, string label)
        {
            if (v == this) return false;
            foreach (Edge e in _neighbours)
            {
                if (e.To == v) return false;
            }
            _neighbours.Add(new Edge(this, v, label, weight));
            return true;
        } 

        public string showNeighbours()
        {
            string return_string;
            return_string = "Sasiedzi: ";
            long counter = 0;
            if (_neighbours.Count == 0) return return_string + "brak.\n";
            foreach(Edge e in _neighbours)
            {
                return_string += e.To.Number + ", ";
                if(((++counter) % 8) == 0)
                {
                    return_string += "\n";
                }    
            }
            return return_string + "\n";
        }

        public override string ToString()
        {
            return "Wierzcholek nr " + Number + " Colour: " + colour + "\n" + showNeighbours();
        }

        static public bool operator == (Vertex e, Vertex f)
        {
            if ((object.ReferenceEquals(e, null)) && (object.ReferenceEquals(f, null)))
            {
                return true;
            }
            else if (object.ReferenceEquals(e, null))
            {
                return false;
            }
            else if (object.ReferenceEquals(f, null))
            {
                return false;
            }
            else
            {
                if (e.Number == f.Number) return true;
                else return false;
            }
        }

        static public bool operator != (Vertex e, Vertex f)
        {
            return !(e == f);
        }

        public override bool Equals(object obj)
        {
            if (obj is Vertex)
            {
                return this == (Vertex)obj;
            }
            else return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
