using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Track_Project
{
    public abstract class Operation
    {

    }
    public class Operation<T>:Operation
    {
        private T _operation;
        Operation()
        {

        }
        Operation(T operation)
        {
            _operation = operation;
        }
        public void AddOperation(T operation)
        {
            _operation = operation;
        }
        public T GetOperation()
        {
            return _operation;
        }
    }
}
