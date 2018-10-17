using System;
using System.Threading;

namespace ProjectCeilidh.Ceilidh.EtoShell.Support
{
    public class Dispatcher : IDisposable
    {
        private readonly SemaphoreSlim _queueSemaphore;
        private readonly CancellationTokenSource _cancelSource;

        public Dispatcher()
        {
            _queueSemaphore = new SemaphoreSlim(0);
            _cancelSource = new CancellationTokenSource();
        }

        public void Run()
        {
            while (_queueSemaphore.Wait(_cancelSource.Token))
            {

            }
        }

        public void Shutdown()
        {

        }

        public void Dispose()
        {
            _queueSemaphore.Dispose();
        }
    }
}
