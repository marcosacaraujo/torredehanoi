using CoreApp.Infra.Data.Context;
using CoreApp.Infra.Data.Entities;
using CoreApp.Infra.Data.Repositories;
using CoreApp.TorreDeHanoi;
using log4net;
using System;
using System.Collections.Generic;

namespace CoreApp.Domain.TorreDeHanoi
{
    public class HanoiResolver : Engine
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(HanoiResolver));

        public HanoiResolver()
        {
            ID = Guid.NewGuid();
            Torres = new List<Torre>() { new Torre(0), new Torre(1), new Torre(2) };
            Movimentos = new List<Movimento>();

            // Inicializando o primeiro Disco
            for (int i = NumeroDeDiscos - 1; i >= 0; i--)
            {
                Torres[0].AddDisk(new Disco(i));
            }
        }

        public HanoiResolver(int numeroDeDiscos)
        {
            ID = Guid.NewGuid();
            NumeroDeDiscos = numeroDeDiscos;
            Torres = new List<Torre>() { new Torre(0), new Torre(2), new Torre(2) };
            Movimentos = new List<Movimento>();

            // Inicializando o primeiro Disco
            for (int i = NumeroDeDiscos - 1; i >= 0; i--)
            {
                Torres[0].AddDisk(new Disco(i));
            }
        }

        public override void Resolve()
        {
            Movimentos = new List<Movimento>();
            Algoritmo(NumeroDeDiscos - 1, 0, 2);
        }

        public override void SaveMovimento(Movimento movimento)
        {
            using (GenericRepository<Historico> _repository = new GenericRepository<Historico>(new AplicationContext()))
            {
                Log.Info("ID: " + ID.ToString() + movimento.ToString());
                _repository.Insert(new Historico() { ID = ID, De = movimento.De.Numero, Para = movimento.Para.Numero, Movimentacao = movimento.ToString(), DataHora = DateTime.Now });
                _repository.Commit();
                Movimentos.Add(movimento);
            }            
        }

        private void Algoritmo(int disco, int de, int para)
        {
            // Pausa em cada Execusão.
            System.Threading.Thread.Sleep(2000);

            if (disco == -1)
            {
                return;
            }
            int torreAux = GetAux(de, para);

            Algoritmo(disco - 1, de, torreAux);

            SaveMovimento(new Movimento(disco, Torres[de], Torres[para]));

            Algoritmo(disco - 1, torreAux, para);
        }

        private int GetAux(int de, int para)
        {
            return (3 - de - para);
        }
    }
}
