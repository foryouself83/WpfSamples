using System;
using System.Collections.Generic;

namespace CoreSamples.Services.Impl
{
    public class EventBrokerService : IEventBrokerService
    {
        private readonly Dictionary<Type, List<Action<object>>> _subscriptions = new Dictionary<Type, List<Action<object>>>();

        public void Subscribe<TEvent>(Action<TEvent> action) where TEvent : notnull
        {
            Type eventType = typeof(TEvent);

            if (!_subscriptions.ContainsKey(eventType))
            {
                _subscriptions[eventType] = new List<Action<object>>();
            }

            _subscriptions[eventType].Add(o => action((TEvent)o));
        }

        public void Publish<TEvent>(TEvent @event) where TEvent : notnull
        {
            Type eventType = typeof(TEvent);

            if (_subscriptions.ContainsKey(eventType))
            {
                foreach (var action in _subscriptions[eventType])
                {
                    action.Invoke(@event);
                }
            }
        }
    }

}
