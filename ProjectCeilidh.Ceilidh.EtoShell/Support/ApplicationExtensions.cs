using System;
using System.Runtime.CompilerServices;
using Eto.Forms;

namespace ProjectCeilidh.Ceilidh.EtoShell.Support
{
    public static class ApplicationExtensions
    {
        private static readonly ConditionalWeakTable<Application, Dispatcher> DispatcherTable = new ConditionalWeakTable<Application, Dispatcher>();

        public static Dispatcher AttachDispatcher(this Application app)
        {
            var dispatcher = new Dispatcher();
            DispatcherTable.Add(app, dispatcher);
            return dispatcher;
        }

        public static Dispatcher GetDispatcher(this Application app)
        {
            if (!DispatcherTable.TryGetValue(app, out var dispatcher)) throw new NotSupportedException();

            return dispatcher;
        }
    }
}
