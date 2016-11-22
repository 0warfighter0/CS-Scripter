using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Scripter
{
    public class CodeFile : CodeLine
    {
        public CodeFile(string target) : base(CodeLineType.File, target)
        { }
    }
}
