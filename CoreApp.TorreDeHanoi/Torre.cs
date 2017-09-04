using System.Collections.Generic;
using System.Linq;

namespace CoreApp.TorreDeHanoi
{
    public class Torre
    {
        public SortedList<int, Disco> Discos { get; set; }
        public int Numero { get; set; }

        public Torre(int numero)
        {
            Discos = new SortedList<int, Disco>();
            Numero = numero;
        }

        public bool IsEmpty()
        {
            return Discos.Count == 0;
        }

        public bool AllowDisk(Disco disco)
        {
            if (disco == null)
            {
                return false;
            }
            if (Discos.Count == 0)
            {
                return true;
            }
            return GetTopDisk().Peso > disco.Peso;
        }

        public Disco GetTopDisk()
        {
            if (Discos.Count > 0)
            {
                return Discos.First().Value;
            }
            return null;
        }

        public void RemoveDisk()
        {
            Discos.Remove(Discos.First().Key);
        }

        public void AddDisk(Disco disco)
        {
            if (disco == null)
            {
                return;
            }
            if (AllowDisk(disco))
            {
                Discos.Add(disco.Peso, disco);
            }
        }

        override public string ToString()
        {
            return "Torre " + ((EnumTorre)Numero).ToString();
        }

        public override bool Equals(object o)
        {
            if (o == null)
            {
                return false;
            }

            Torre torre = o as Torre;
            if (torre == null)
            {
                return false;
            }
            return torre.Numero == Numero;
        }
    }
}