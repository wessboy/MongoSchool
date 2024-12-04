using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Events
{
    public class WeakEvent<TEventArgs> where TEventArgs : EventArgs
    {
        private readonly List<WeakReference<EventHandler<TEventArgs>>> _eventHandlers = [];

        public void AddEventHandler(EventHandler<TEventArgs> handler)
        {
            if (handler is null) return;

            _eventHandlers.Add(new WeakReference<EventHandler<TEventArgs>>(handler));
        }


        public void RemoveEventHandler(EventHandler<TEventArgs> handler)
        {
          var eventHandler =  _eventHandlers.FirstOrDefault(wr =>
            {
                wr.TryGetTarget(out var target);



                return handler == target;

            });

            if(eventHandler is null) return;

            _eventHandlers.Remove(eventHandler);
        }

        public void RaiseEvent(object sender, TEventArgs e)
        {
            foreach (var handler in _eventHandlers)
            {
                if(handler.TryGetTarget(out var eventHandler))
                {
                    eventHandler(sender,e);
                }
            }
        }
    }
}
