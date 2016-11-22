using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Scripter
{
    /// <summary>
    /// comment
    /// int x;// declaration!
    /// x = 5;// operation
    /// string s = "abc";// declaration (l) + operation(r)
    /// s.Length;// Property/variable
    /// s.Substring(1,2);// function call!
    /// </summary>

    public class CodeAction : CodeLine
    {
        public string VariableType;
        public string Namespace;

        public CodeAction(CodeLineType type, string varType, string target, string codeNamespace = "") : base(type, target)
        {
            VariableType = varType;
            Namespace = codeNamespace;
        }
    }
}
