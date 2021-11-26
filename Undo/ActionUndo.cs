using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Undo
{
    public class ActionUndo
    {
        public int type { get; set; } // 1 edit cell // 2 add // 3 delete
        public object obj { get; set; }
        public object value { get; set; }

        public ActionUndo(int type, object obj, object value)
        {
            this.type = type;
            this.obj = obj;
            this.value = value;
        }
    }
}
