using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RangeExceptions
{
    class InvalidRangeException<T> : ArgumentOutOfRangeException
    {
        private T start;
        private T end;

        public T Start
        {
            get
            {
                return this.start;
            }
            private set
            {
                this.start = value;
            }
        }

        public T End
        {
            get
            {
                return this.end;
            }
            private set
            {
                this.end = value;
            }
        }

        public InvalidRangeException(string inputMsg, T inputStart, T inputEnd, Exception innerEx)
            : base(inputMsg, innerEx)
        {
            this.Start = inputStart;
            this.End = inputEnd;
        }

        public InvalidRangeException(string inputMsg, T inputStart, T inputEnd)
            : this(inputMsg, inputStart, inputEnd, null)
        {

        }
    }
}
