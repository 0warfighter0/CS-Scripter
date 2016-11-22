using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Scripter
{
    public class CodeOperator : CodeFunction
    {
        public CodeOperator(string returnType, string target, string functionName, string[] parameterTypes, string[] parameterValues) : base(CodeLineType.CodeOperator, returnType, target, functionName, parameterTypes, parameterValues)
        {

        }
    }
}
