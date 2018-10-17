using System;
using System.Threading;

namespace ProjectCeilidh.Ceilidh.EtoShell
{
    internal static class Extensions
    {
        public static bool WaitCancellable(this SemaphoreSlim semaphore, CancellationToken token)
        {
            try
            {
                semaphore.Wait(token);
                return true;
            }
            catch (OperationCanceledException)
            {
                return false;
            }
        }
    }
}
