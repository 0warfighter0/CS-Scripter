using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace CS_Scripter
{
    public class CSParser
    {
        public CodeLine CodeTree = null;

        private void GenerateCodeTree(string code, CodeLine parent)
        {
            if (code.Trim().Length == 0) return;// null;

            string nextCodeBlock = GetNextCodeBlock(code);
            //string cCB = code.
            string[] codeLines = CodeBlockToLines(nextCodeBlock);
            for (int i = 0; i < codeLines.Length; i++)
            {
                string line = codeLines[i].Trim();

                int e = FindClosingIndex(code);
                int s = code.IndexOf('{') + 1;
                string nextInnerBlock = "";
                if(code.Contains('{')) nextInnerBlock = code.Substring(s, e - s);

                CodeLine current = null;
                string keyword = GetWord(line, 0);
                string target = GetWord(line, 1);
                switch (keyword)
                {
                    case "using":
                        current = new CodeLine(CodeLineType.Namespace, target);
                        break;
                    case "//":
                        target = line.Trim().Substring(2).Trim();
                        current = new CodeLine(CodeLineType.Comment, target);
                        break;
                    case "namespace":
                        current = new CodeLine(CodeLineType.Namespace, target);
                        GenerateCodeTree(nextInnerBlock, current);
                        //newCode = newCode.Substring(0,)
                        break;
                    case "class":
                        // derived class not added yet
                        current = new CodeClass(target);
                        GenerateCodeTree(nextInnerBlock, current);
                        break;
                    case "void":
                        // hardcoded for now
                        current = new CodeFunction(CodeLineType.FunctionDefinition ,keyword, parent.Target, target, null, null);
                        GenerateCodeTree(nextInnerBlock, current);
                        break;
                    default:
                        ParseCodeAction(line, ref parent.Children);
                        break;
                }
                if(current != null) parent.Children.Add(current);


            }
            return;
        }
        private void ParseCodeAction(string line, ref List<CodeLine> children)
        {
            if (line.Contains("//"))
            {
                int end = line.IndexOf('\n');
                if (end == -1) end = line.Length;
                string target = line.Substring(2, end - 2).Trim();
                CodeLine action = new CodeLine(CodeLineType.Comment, target);
                children.Add(action);
            }
            else if (line.Contains('='))
            {
                string assign = line.Substring(line.IndexOf('=')+1).Trim();
                string before = line.Substring(0, line.IndexOf('=')).Trim();

                if (before.Contains(" "))
                {
                    // Is variable declaration
                    string type = GetWord(before, 0);
                    string target = GetWord(before, 1);

                    CodeAction action = new CodeAction(CodeLineType.VariableDeclaration, type, target);
                    children.Add(action);
                }

                if (assign.Contains("new ") && !assign.Contains("."))
                {
                    // Is Constructor
                    string type = GetWord(before, 0);
                    string target = GetWord(before, 1);

                    int start = line.IndexOf('(') + 1;
                    int end = line.IndexOf(')') - start;

                    string parameters = line.Substring(start, end);

                    string[] param = parameters.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    string[] paramTypes = null;
                    for (int i = 0; i < param.Length; i++) param[i] = StripEnum(param[i].Trim());

                    CodeConstructor action = new CodeConstructor(type, target, "Constructor", paramTypes, param);
                    children.Add(action);
                }
                /*else
                {
                    if(before.Contains('.'))
                    {
                        string target = before.Substring(0, before.IndexOf('.'));
                        int start = before.IndexOf('.') + 1;
                        string variable = before.Substring(start);

                        start = line.IndexOf('{') + 1;
                        int end = line.IndexOf('}') - start;

                        string parameters = line.Substring(start, end);

                        string[] param = parameters.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                        string[] paramTypes = new string[] { assign.Substring(0, assign.IndexOf('{')).Replace("new ", "") };
                        for (int i = 0; i < param.Length; i++) param[i] = param[i].Trim();

                        action = new CodeOperator(variable, target, "Assignment", paramTypes, param);
                    }
                }*/
            }
            else if (line.Contains('('))
            {
                // Function call

                string funcBody = line.Substring(0, line.IndexOf('('));
                string target = "";
                string funcName = "";
                int start = 0;
                if (funcBody.Contains('.'))
                {
                    target = funcBody.Substring(0, line.IndexOf('.'));
                    start = line.IndexOf('.') + 1;
                    funcName = funcBody.Substring(start, line.IndexOf('(') - start);
                }
                else
                {
                    funcName = funcBody;
                }

                start = line.IndexOf('(')+1;
                int end = line.IndexOf(')') - start;

                string parameters = line.Substring(start, end);

                string[] param = parameters.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                string[] paramTypes = null;
                for (int i = 0; i < param.Length; i++) param[i] = StripEnum(param[i].Trim());

                if(line.Substring(0, line.IndexOf('(')).Trim().Contains(' '))
                {
                    funcName = funcName.Substring(funcName.IndexOf(' '));
                }

                // Needs to be read using reflection
                string returnType = "void";
                CodeFunction action = new CodeFunction(returnType, target, funcName, paramTypes, param);
                children.Add(action);
            }
        }

        private string StripEnum(string enumValue) { return enumValue.Contains('.') ? enumValue.Substring(enumValue.IndexOf('.') + 1) : enumValue; }

        bool IsArrayBrace(string code)
        {
            int bracePos = code.IndexOf('{');
            string beforeBrace = code.Substring(0, bracePos).Trim();
            int arrayPos = beforeBrace.LastIndexOf("[]");
            if (arrayPos == -1) return false;

            return true;
        }
        private string GetNextCodeBlock(string code)
        {
            string block = "";

            // No brace?
            if (code.IndexOf('{') == -1) return code;

            // Part before brace?
            if(!IsArrayBrace(code))
            {
                block = code.Substring(0, code.IndexOf('{')).Trim();
                if (block.Length > 0) return block;
            }


            // Part in brace?
            //int outerEnd = code.IndexOf('{');
            //int closingIndex = FindClosingIndex(code);
            //int innerEnd = closingIndex - outerEnd;
            //
            ////string outerBlock = code.Substring(0, outerEnd).Trim();
            //string innerBlock = code.Substring(outerEnd+1, innerEnd-1).Trim();
            //
            ////block = outerBlock;
            //block = innerBlock;
            block = code;

            return block;
        }
        private string[] CodeBlockToLines(string block)
        {
            //List<string> lines = new List<string>();
            string[] lines = block.Split(new string[] { "\n", ";" }, StringSplitOptions.RemoveEmptyEntries);
            return lines.ToArray();
        }

        private string GetTypeFromParam(string param)
        {
            // Should be done with reflection to the referenced DLL
            if (param.ToLower() == "true" || param.ToLower() == "false") return "bool";

            return "unknown";
        }
        private string RemoveEmptyLines(string lines)
        {
            return Regex.Replace(lines, @"^\s*$\n|\r", "", RegexOptions.Multiline).TrimEnd();
        }
        string GetWord(string line, int wordNr)
        {
            string[] words = line.Split(new char[] { ' ', ';', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            if (wordNr < words.Length) return (words[wordNr]);

            return null;
        }
        int FindClosingIndex(string text, char addLevel = '{', char subLevel = '}')
        {
            int closingIndex = -1;
            int lvl = 0;

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == addLevel) ++lvl;
                if (text[i] == subLevel)
                {
                    --lvl;
                    if (lvl == 0) return i;
                }
            }

            // Not closed
            return closingIndex;
        }
        public CSParser(string path)
        {
            //if(File.Rea)
            string[] lines = File.ReadLines(path).ToArray();
            string text = File.ReadAllText(path);

            text = RemoveEmptyLines(text);
            CodeTree = new CodeFile(new FileInfo(path).Name);
            GenerateCodeTree(text, CodeTree);
        }
    }
}
