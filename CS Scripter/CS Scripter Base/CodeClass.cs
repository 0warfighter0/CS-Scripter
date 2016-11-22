using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Scripter
{
    public class CodeClass : CodeLine
    {
        public string BaseClass = null;
        public CodeClass(string target, string baseClass = null) : base(CodeLineType.Class,target)
        {
            BaseClass = baseClass;
        }
    }
}
