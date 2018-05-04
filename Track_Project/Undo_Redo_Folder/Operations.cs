using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Track_Project 
{
    public class Operations
    { 
        List<Operation> _operations = new List<Operation>();
        public int _index = new int();

        Operations()
        {

        }
        public void AddOperation(Operation operation)
        {
            _operations.Add(operation);
            _index++;
        }
        public void Undo()
        {
            if (_index>0)
                _index--;
        }
        public void Redo()
        {
            if (_index < _operations.Count)
                _index++;
        }
        public void Make()
        {
            _operations.Take(_index);
        }
    }
}
