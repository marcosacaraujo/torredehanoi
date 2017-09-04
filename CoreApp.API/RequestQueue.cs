using System;
using System.Collections.Concurrent;

namespace CoreApp.API
{
    public static class ControladorDeSolucoes
    {
        private static ConcurrentQueue<Guid> Solucoes = new ConcurrentQueue<Guid>();
    }
}