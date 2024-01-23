using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.Results
{
    public class ErrorDataResult<T> : DataResult<T>
    {
        // Mesaj Data ve Success birlikte döner
        public ErrorDataResult(T data, bool success, string message) : base(data, false, message)
        {

        }
        // Data Mesaj ile birlikte döner
        public ErrorDataResult(T data, string message) : base(data, false, message)
        {

        }

        // Data Sadece Success ile birlikte döner
        public ErrorDataResult(T data) : base(data, false)
        {

        }

        // Sadece Mesaj ve Success döner
        public ErrorDataResult(string message) : base(default, false, message)
        {

        }

        // Sadece Success döner
        public ErrorDataResult() : base(default, false)
        {

        }

    }
}
