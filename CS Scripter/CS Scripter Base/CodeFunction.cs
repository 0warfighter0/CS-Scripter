using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Scripter
{
    public class CodeFunction : CodeAction
    {
        public string FunctionName;
        public string[] ParameterTypes;
        public string[] ParameterValues;

        public CodeFunction(string returnType, string target, string functionName, string[] parameterTypes, string[] parameterValues) : base(CodeLineType.FunctionCall, returnType, target)
        {
            FunctionName = functionName;
            ParameterTypes = parameterTypes;
            ParameterValues = parameterValues;
        }

        public CodeFunction(CodeLineType type, string returnType, string target, string functionName, string[] parameterTypes, string[] parameterValues) : base(type, returnType, target)
        {
            FunctionName = functionName;
            ParameterTypes = parameterTypes;
            ParameterValues = parameterValues;
        }
        //public CodeFunction(string line) : base(CodeLineType.FunctionCall, line.Substring(0, line.IndexOf(' '), line.Substring(0, line.IndexOf(' '))
        //{
        //    FunctionName = functionName;
        //    ParameterTypes = parameterTypes;
        //    ParameterValues = parameterValues;
        //}
    }
}
