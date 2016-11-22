using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Scripter
{
    public class CodeLine
    {
        public CodeLineType CodeActionType;
        public string Target;// l value
        public List<CodeLine> Children = new List<CodeLine>();

        public CodeLine(CodeLineType type, string target)
        {
            CodeActionType = type;
            Target = target;
        }
    }

    public enum CodeLineType
    {
        File,
        Reference,
        Namespace,
        Comment,
        Class,
        Constructor,
        FunctionCall,
        FunctionDefinition,
        CodeOperator,
        VariableDeclaration
    }
}
