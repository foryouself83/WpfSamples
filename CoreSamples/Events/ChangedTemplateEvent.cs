namespace CoreSamples.Events
{
    /// <summary>
    /// TempateView 에서 사용하는 Event
    /// </summary>
    public class ChangedTemplateEvent
    {
        public object? Sender { get; set; }
        public int FontSize { get; set; }
    }
}
