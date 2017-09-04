using System;
using System.Collections.Generic;

namespace CoreApp.TorreDeHanoi
{
    public abstract class Engine
    {
        public Guid ID { get; set; }
        public List<Torre> Torres = new List<Torre>();
        public List<Movimento> Movimentos = new List<Movimento>();
        public int NumeroDeDiscos = 3;

        public abstract void Resolve();
        public abstract void SaveMovimento(Movimento movimento);
    }
}