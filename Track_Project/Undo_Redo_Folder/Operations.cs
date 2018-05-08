using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Track_Project 
{
    public class Operations
    {
        public List<Operation> _operations = new List<Operation>();
        public int _index { get; set; } = new int();

        public Operations()
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
        public Point[] Redo()
        {
            List<Point> list_point = new List<Point>();
            if (_index < _operations.Count)
            {
                _index++;
                _operations[_index-1].GetOperationPoints(list_point);
            }
            return list_point.ToArray();
        }
        public void Make(Operation operation)
        {
            _operations=_operations.Take(_index).ToList();
            AddOperation(operation);
        }
        public List<Operation> GetOperations()
        {
            return _operations;
        }
    }
}
