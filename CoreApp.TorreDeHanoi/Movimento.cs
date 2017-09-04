namespace CoreApp.TorreDeHanoi
{
    public class Movimento
    {
        public Torre De { get; set; }
        public Torre Para { get; set; }
        
        public int Disco { get; set; }

        public Movimento(int disco, Torre de, Torre para)
        {
            De = de;
            Para = para;
            Disco = disco;
        }

        public bool AffectCount()
        {
            if (Para.Equals(De))
            {
                return false;
            }
            return IsValid();
        }

        public bool IsValid()
        {
            if (Para.Equals(De))
            {
                return true;
            }
            return Para.AllowDisk(De.GetTopDisk());
        }

        public override string ToString()
        {
            if (De == null || Para == null)
            {
                return "Não existe torres";
            }
            return "O Disco " + Disco.ToString() + " foi movido da torre " + De.ToString() + " para " + Para.ToString();
        }

        public override bool Equals(object o)
        {
            if (o == null)
            {
                return false;
            }
            Movimento m = o as Movimento;
            if (m == null)
            {
                return false;
            }
            return m.De.Numero == m.De.Numero && m.Para.Numero == m.Para.Numero;
        }
    }
}