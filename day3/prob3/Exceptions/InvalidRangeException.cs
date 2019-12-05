using System;
using System.Collections.Generic;
using System.Text;

namespace prob3.Exceptions
{
    [System.Serializable]
    class InvalidRangeException<T> : Exception
    {
        private static readonly string DefaultMessage = "Out of range exception.";

        public T Min { get; set; }
        public T Max { get; set; }

        public T ActualValue { get; set; }

        public override string Message
        {
            get
            {
                if (this.Min != null && this.Max != null && this.ActualValue != null)
                {
                    return $"Value entered {this.ActualValue} is out of range [{this.Min} ... {this.Max}]";
                }

                return DefaultMessage;
            }           
        }

        public InvalidRangeException() : base(DefaultMessage) { }
        public InvalidRangeException(string message) : base(message) { }
        public InvalidRangeException(string message, System.Exception innerException) : base(message, innerException) { }
        public InvalidRangeException(T act, T min, T max)
        {
            this.ActualValue = act;
            this.Min = min;
            this.Max = max;
        }

        protected InvalidRangeException(
        System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
