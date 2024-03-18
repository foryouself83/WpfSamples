using System;

namespace CoreSamples.Services
{
    public interface IEventBrokerService
    {
        void Publish<TEvent>(TEvent ev) where TEvent : notnull;
        void Subscribe<TEvent>(Action<TEvent> action) where TEvent : notnull;
    }
}