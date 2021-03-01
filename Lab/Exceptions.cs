using System;

namespace Lab
{
    class DateSpanException : Exception
    {
        public DateSpanException() : base() { }
        public DateSpanException(string message) : base(message) { }
    }
    class TooBigSpanException : Exception
    {
        public TooBigSpanException() : base() { }
        public TooBigSpanException(string message) : base(message) { }
    }
}
