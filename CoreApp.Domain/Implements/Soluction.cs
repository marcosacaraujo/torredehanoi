using CoreApp.Domain.Interfaces;
using CoreApp.Domain.Model;
using System.Web.Hosting;
using CoreApp.Domain.TorreDeHanoi;
using CoreApp.Infra.Data.Interfaces;
using CoreApp.Infra.Data.Entities;
using CoreApp.Infra.Data.Repositories;
using CoreApp.Infra.Data.Context;
using System.Linq;

namespace CoreApp.Domain.Implements
{
    public class Soluction : ISoluction
    {
        private readonly IGenericRepository<Historico> _repository;

        public Soluction()
        {
            _repository = new GenericRepository<Historico>(new AplicationContext());
        }
        
        public ResultSoluction GetHistorico(string Id)
        {
            return new ResultSoluction()
            {
                Movimentos = _repository.Get(h => h.ID.ToString() == Id, orderBy: h => h.OrderByDescending(d => d.DataHora) ).ToList(),
                ID = Id
            };
        }

        public ResultSoluction Start(int quantidadeDeDiscos)
        {
            HanoiResolver _engineSoluction = new HanoiResolver(quantidadeDeDiscos);

            // Executando em backgroud a Solucao
            HostingEnvironment.QueueBackgroundWorkItem(ct => _engineSoluction.Resolve());

            return new ResultSoluction()
            {
                ID = _engineSoluction.ID.ToString()
            };
        }
    }
}