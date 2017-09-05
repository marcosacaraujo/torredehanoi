using CoreApp.Domain.Model;

namespace CoreApp.Domain.Interfaces
{
    public interface ISoluction
    {
        ResultSoluction Start(int QuantidadeDeDiscos);
        ResultSoluction GetHistorico(string Id);
    }
}