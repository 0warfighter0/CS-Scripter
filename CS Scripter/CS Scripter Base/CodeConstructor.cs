using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Scripter
{
    public class CodeConstructor : CodeFunction
    {
        public CodeConstructor(string returnType, string target, string functionName, string[] parameterTypes, string[] parameterValues) : base(CodeLineType.Constructor, returnType, target, functionName, parameterTypes, parameterValues)
        {

        }
    }
}
