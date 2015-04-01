namespace Lib
{
    class Answer
    {
        public Answer(MessageType type,string message)
        {
            Type = type;
            Message = message;
        }

        public MessageType Type { get; private set; }
        public string Message { get; private set; }
    }

    public enum MessageType
    {
        Positive,
        Negative,
        HalfPositive,
        Neutral
    }
}
