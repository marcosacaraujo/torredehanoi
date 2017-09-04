namespace CoreApp.TorreDeHanoi
{
    public class Disco
    {
        public int Peso { get; set; }

        public Disco(int peso)
        {
            Peso = peso;
        }

        public override string ToString()
        {
            return Peso.ToString();
        }

        public override bool Equals(object o)
        {
            if (o == null)
            {
                return false;
            }

            Disco d = o as Disco;
            if (d == null)
            {
                return false;
            }
            return d.Peso == Peso;
        }
    }
}