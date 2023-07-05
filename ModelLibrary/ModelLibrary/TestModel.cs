using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary
{
    public enum TaskType
    {
        Addition,
        Subtraction,
        Multiplication,
        Division
    }
    public class TestModel
    {
        public string userName { get; set; }
        public float Number1 { get; set; }
        public float Number2 { get; set; }
        public TaskType Task { get; set; }
    }
}
