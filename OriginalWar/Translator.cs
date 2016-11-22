using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CS_Scripter;

namespace OriginalWar
{
    public class Translator : ITranslator
    {
        static string inputPath = @"E:\Repos\CS Scripter\MyMod\Missions\";
        static string outputPath = @"F:\Steam\steamapps\common\Original War\mods\MyMod\Missions\_Multiplayer\Test\main.src";

        List<string> exportableObjects = new List<string>();

        private string GenerateScript(CodeLine code, ref List<string> exportableObjects)
        {
            StringBuilder sb = new StringBuilder();

            switch (code.CodeActionType)
            {
                case CodeLineType.File:
                    break;
                case CodeLineType.Reference:
                    break;
                case CodeLineType.Namespace:
                    break;
                case CodeLineType.Comment:
                    sb.Append("// ");
                    sb.Append(code.Target);
                    sb.Append(Environment.NewLine);
                    break;
                case CodeLineType.Class:
                case CodeLineType.FunctionDefinition:
                    break;
                case CodeLineType.Constructor:
                    CodeConstructor constructor = code as CodeConstructor;

                    if(constructor.VariableType == "Human")
                    {
                        sb.Append("InitHc;");
                        sb.Append(Environment.NewLine);

                        /*
                        hc_agressivity, hc_attr, hc_basic_skills, hc_class, hc_face_number, hc_gallery, hc_importance, hc_last_mission, hc_name, hc_sex, hc_skills
                        */
                        //Nation nation, Class classType, Sex sex, string name
                        if (constructor.ParameterValues.Length == 4)
                        {
                            sb.Append("uc_side = ");
                            sb.Append(constructor.ParameterValues[0]);
                            sb.Append(";");
                            sb.Append(Environment.NewLine);
                            sb.Append("uc_nation = ");
                            sb.Append(constructor.ParameterValues[1]);
                            sb.Append(";");
                            sb.Append(Environment.NewLine);
                            sb.Append("hc_class = ");
                            sb.Append(constructor.ParameterValues[2]);
                            sb.Append(";");
                            sb.Append(Environment.NewLine);
                            sb.Append("hc_sex = ");
                            sb.Append(constructor.ParameterValues[3]);
                            sb.Append(";");
                            sb.Append(Environment.NewLine);
                        }
                        if (constructor.ParameterValues.Length == 5)
                        {
                            sb.Append("hc_name = ");
                            sb.Append(constructor.ParameterValues[4]);
                            sb.Append(";");
                            sb.Append(Environment.NewLine);
                        }

                        sb.Append(constructor.Target);
                        sb.Append(" = CreateHuman;");
                        sb.Append(Environment.NewLine);
                        /*
                        InitHc;
                        uc_side = nation_american;
                        hc_class = class_engineer;
                        hc_basic_skills = [2,0,0,0];
                        Bob = CreateHuman;
                        */
                    }

                    exportableObjects.Add($"Export {constructor.Target};{Environment.NewLine}");
                    break;
                case CodeLineType.FunctionCall:
                    CodeFunction function = code as CodeFunction;

                    if(function.FunctionName == "Starting")
                    {
                        sb.Append(function.FunctionName);
                        sb.Append(Environment.NewLine);
                        sb.Append("Begin");
                        sb.Append(Environment.NewLine);
                    }
                    else
                    {
                        sb.Append(function.FunctionName);
                        sb.Append('(');
                        if (function.Target.Length > 0)
                        {
                            sb.Append(function.Target);
                            if (function.ParameterValues.Length > 0) sb.Append(", ");
                        }
                        for (int i = 0; i < function.ParameterValues.Length; i++)
                        {
                            sb.Append(function.ParameterValues[i]);
                            if (i < function.ParameterValues.Length - 1)
                            {
                               if(function.FunctionName=="Wait") sb.Append("$ ");
                                else sb.Append(", ");
                            }
                        }
                        sb.Append(");");
                        sb.Append(Environment.NewLine);
                    }
                    break;
                case CodeLineType.CodeOperator:
                    CodeOperator action = code as CodeOperator;
                    if(action.FunctionName == "Assignment")
                    {
                        if(action.VariableType == "Skills")
                        {
                            if (action.ParameterValues.Count() != 4) throw new Exception("Skills does not have 4 parameters!");

                            sb.Append("hc_basic_skills = [");
                            for (int i = 0; i < 4; i++)
                            {
                                sb.Append(action.ParameterValues[i]);
                                if(i < 3) sb.Append(", ");
                            }
                            sb.Append("];");
                            sb.Append(Environment.NewLine);
                        }
                    }
                    break;
                default:
                    break;
            }

            for (int i = 0; i < code.Children.Count; i++)
            {
                // Ignore constructors that stand for objects defined in the editor
                if (!(code.CodeActionType == CodeLineType.Class && code.Children[i].CodeActionType == CodeLineType.Constructor))
                {
                    sb.Append(GenerateScript(code.Children[i], ref exportableObjects));
                }
            }

            return sb.ToString();
        }

        private void CreateHuman()
        {

        }

        public bool Translate()
        {
            try
            {
                StringBuilder sBuilder = new StringBuilder();

                var files = Directory.EnumerateFiles(inputPath, "*.cs", SearchOption.AllDirectories);
                foreach (string path in files)
                {
                    CSParser parser = new CSParser(path);
                    string script = GenerateScript(parser.CodeTree, ref exportableObjects);

                    for (int i = 0; i < exportableObjects.Count; i++)
                    {
                        sBuilder.Append(exportableObjects[i]);
                    }
                    sBuilder.Append(Environment.NewLine);
                    sBuilder.Append(script);
                    sBuilder.Append("End;");
                    sBuilder.Append(Environment.NewLine);

                    string outputFilePath = parser.CodeTree.Children[1].Target;
                    outputFilePath = outputFilePath.Replace('.', '\\');
                    outputPath = @"F:\Steam\steamapps\common\Original War\mods\" + outputFilePath + "\\" + new FileInfo(path).Name.Substring(0, new FileInfo(path).Name.LastIndexOf('.')) + ".src";

                    string output = sBuilder.ToString();
                    using (StreamWriter writer = File.CreateText(outputPath))
                    {
                        writer.Write(output);
                    }
                }

                return true;
            }
            catch (Exception e)
            { Console.Write(e); }
            return false;
        }
    }
}
