using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary
{
    public class MessageModel : TestModel
    {
        public string UserName { get; set; }
        public string Ip { get; set; }
        public DateTime intialTime { get; set; }
    }
}
