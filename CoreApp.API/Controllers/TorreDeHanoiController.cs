using CoreApp.Domain.Implements;
using CoreApp.Domain.Interfaces;
using CoreApp.Domain.Model;
using System.Web.Http;

namespace CoreApp.API.Controllers
{
    public class TorreDeHanoiController : ApiController
    {
        private readonly ISoluction _soluction;

        public TorreDeHanoiController()
        {
            _soluction = new Soluction();
        }

        [HttpPost]
        public ResultSoluction StartSoluction(int QtdDiscos)
        {
            return _soluction.Start(QtdDiscos);
        }

        [HttpGet]
        public ResultSoluction Get(string Id)
        {
            return _soluction.GetHistorico(Id);
        }
    }
}