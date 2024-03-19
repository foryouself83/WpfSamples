using System;
using System.Collections.Generic;

namespace CoreSamples.Services.Impl
{
    public class EventBrokerService : IEventBrokerService
    {
        private readonly Dictionary<Type, List<Action<object, object>>> _subscriptions = new Dictionary<Type, List<Action<object, object>>>();

        public void Publish<TEvent>(object serder, TEvent @event) where TEvent : notnull
        {
            Type eventType = typeof(TEvent);

            if (_subscriptions.ContainsKey(eventType))
            {
                foreach (var action in _subscriptions[eventType])
                {
                    action.Invoke(serder, @event);
                }
            }
        }

        public void Subscribe<TEvent>(Action<object, TEvent> action) where TEvent : notnull
        {
            Type eventType = typeof(TEvent);

            if (!_subscriptions.ContainsKey(eventType))
            {
                _subscriptions[eventType] = new List<Action<object, object>>();
            }

            _subscriptions[eventType].Add((sender, obj) => action(sender, (TEvent)obj));
        }

        public void UnSubscribe<TEvent>(Action<object, TEvent> action) where TEvent : notnull
        {
            Type eventType = typeof(TEvent);

            if (_subscriptions.ContainsKey(eventType))
            {
                var subscriptions = _subscriptions[eventType];
                subscriptions.Clear();
            }
        }
    }

}
