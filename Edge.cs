using System;

namespace Grafy
{
    public class Edge
    {
        private Vertex _from;
        private Vertex _to;
        private string _label;
        private int _weight;

        public Vertex From
        {
            get
            {
                return _from;
            }
            private set
            {
                if (value != null)
                {
                    _from = value;
                }
                else throw new ArgumentNullException();
            }
        }

        public Vertex To
        {
            get
            {
                return _to;
            }
            private set
            {
                if (value != null)
                {
                    _to = value;
                }
                else throw new ArgumentNullException();
            }
        }

        public string Label
        {
            get
            {
                return _label;
            }
            private set
            {
                if (value != null)
                {
                    _label = value;
                }
                else throw new ArgumentNullException();
            }
        }

        public int Weight
        {
            get
            {
                return _weight;
            }
            private set
            {
                if (value > 0)
                {
                    _weight = value;
                }
                else throw new TooLowValueExcepion(value, 0);
            }
        }

        public Edge(Vertex from_t, Vertex to_t, string label_t, int weight_t)
        {
            From = from_t;
            To = to_t;
            Label = label_t;
            Weight = weight_t;
        }

        public override string ToString()
        {
            return "Krawedz " + Label + " z " + From.Number + " do " + To.Number + " o wadze " + Weight + ".\n";
        }

        static public bool operator == (Edge e, Edge f)
        {
            if (object.ReferenceEquals(e, null))
            {
                return false;
            }
            else if (object.ReferenceEquals(f, null))
            {
                return false;
            }
            else if ((object.ReferenceEquals(e, null)) && (object.ReferenceEquals(f, null)))
            {               
                return true;
            }
            else
            {
                if ((e.From == f.From) && (e.To == f.To)) return true;
                else return false;
            }
        }

        static public bool operator != (Edge e, Edge f)
        {
            return !(e == f);
        }

        public override bool Equals(object obj)
        {
            if (obj is Edge)
            {
                return this == (Edge)obj;
            }
            else return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
