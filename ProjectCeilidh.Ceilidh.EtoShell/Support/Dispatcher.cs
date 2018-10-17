using System;
using System.Collections.Concurrent;
using System.Threading;

namespace ProjectCeilidh.Ceilidh.EtoShell.Support
{
    public class Dispatcher : IDisposable
    {
        private readonly SemaphoreSlim _queueSemaphore;
        private readonly CancellationTokenSource _cancelSource;
        private readonly ConcurrentQueue<DispatcherItem> _itemQueue;

        public Dispatcher()
        {
            _queueSemaphore = new SemaphoreSlim(0);
            _cancelSource = new CancellationTokenSource();
            _itemQueue = new ConcurrentQueue<DispatcherItem>();
        }

        public void Run()
        {
            while (_queueSemaphore.WaitCancellable(_cancelSource.Token))
            {
                DispatcherItem action;
                while (!_itemQueue.TryDequeue(out action)) { }

                action.Action();

                action.ActionComplete?.Set();
            }
        }

        public void Invoke(Action action)
        {
            using (var item = new DispatcherItem(action, true))
            {
                _itemQueue.Enqueue(item);
                _queueSemaphore.Release();
                item.ActionComplete.Wait();
            }
        }

        public void InvokeAsync(Action action)
        {
            _itemQueue.Enqueue(new DispatcherItem(action, false));
            _queueSemaphore.Release();
        }

        public void Shutdown()
        {
            _cancelSource.Cancel();
        }

        public void Dispose()
        {
            _queueSemaphore.Dispose();
            _cancelSource.Dispose();
        }

        private class DispatcherItem : IDisposable
        {
            public Action Action { get; }
            public ManualResetEventSlim ActionComplete { get; }

            public DispatcherItem(Action action, bool createEvent)
            {
                Action = action;
                if (createEvent)
                    ActionComplete = new ManualResetEventSlim(false);
            }

            public void Dispose() => ActionComplete?.Dispose();
        }
    }
}
