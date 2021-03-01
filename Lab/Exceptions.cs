using System;

namespace Lab
{
    class DateSpanException : Exception
    {
        public DateSpanException() : base()
        {
        }
        public DateSpanException(string message) : base(message)
        {
        }
    }
}
