using System;

namespace CoreSamples.Services
{
    public interface IEventBrokerService
    {
        // event를 게시(발생)
        void Publish<TEvent>(object serder, TEvent @event) where TEvent : notnull;

        // Event 구독하고 발생 시 action을 실행
        void Subscribe<TEvent>(Action<object, TEvent> action) where TEvent : notnull;

        // Event 구독을 취소
        public void UnSubscribe<TEvent>(Action<object, TEvent> action) where TEvent : notnull;
    }
}