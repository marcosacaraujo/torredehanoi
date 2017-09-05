using CoreApp.Domain.TorreDeHanoi;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CoreApp.Test
{
    [TestClass]
    public class TestandoOAlgoritmo
    {
        [TestMethod]
        public void ExecutandoAEngineDeHanoi()
        {
            HanoiResolver _engine = new HanoiResolver(3);

            _engine.Resolve();

            Assert.AreEqual(7, _engine.Movimentos.Count);
        }
    }
}