using System;

namespace Lab
{
    class DateSpanException : Exception
    {
        public DateSpanException() : base() { }
        public DateSpanException(string message) : base(message) { }
    }
    class TooBigNException : Exception
    {
        public TooBigNException() : base() { }
        public TooBigNException(string message) : base(message) { }
    }
}
