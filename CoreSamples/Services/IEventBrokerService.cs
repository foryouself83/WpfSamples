using System;

namespace CoreSamples.Services
{
    public interface IEventBrokerService
    {
        void Publish<TEvent>(object serder, TEvent ev) where TEvent : notnull;
        void Subscribe<TEvent>(Action<object, TEvent> action) where TEvent : notnull;
    }
}