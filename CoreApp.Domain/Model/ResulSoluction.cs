using System.Collections.Generic;
using CoreApp.Infra.Data.Entities;

namespace CoreApp.Domain.Model
{
    public class ResultSoluction
    {
        public string ID { get; set; }
        public List<Historico> Movimentos { get; set; }
    }
}