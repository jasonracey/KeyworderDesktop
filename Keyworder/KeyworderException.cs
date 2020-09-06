using System;

namespace Keyworder
{
    [Serializable]
    public class KeyworderException : Exception
    {
        public KeyworderException() { }
        public KeyworderException(string message) : base(message) { }
        public KeyworderException(string message, Exception inner) : base(message, inner) { }
        protected KeyworderException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}