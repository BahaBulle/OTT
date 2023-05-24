// <copyright file="EVBExtracter.cs" company="BahaBulle">
//     Copyright (c) BahaBulle. All rights reserved.
// </copyright>

namespace OTT.Actions.EVB
{
    using System.Linq;
    using System.Text;
    using NLog;

    public class EVBExtracter
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        private readonly IEnumerable<FileInfo> files;

        public EVBExtracter(IEnumerable<FileInfo> files)
        {
            this.files = files;
        }

        private static StringBuilder GetText(EvbInstructionsCollection instructions, EvbConstantsCollection constants, ref int index)
        {
            var result = new StringBuilder();

            for (; index < instructions.Count;)
            {
                var instruction = instructions[index];

                if (instruction.OpCode == EnumOpCodes.LOADK && constants[(int)instruction.BC].Type == EnumTypesConstant.Number)
                {
                    var value = constants[(int)instruction.BC].Double;

                    if (value != null)
                    {
                        result.AppendLine($"[{CharactersNames.Characters[(int)value]}-{value}]");
                    }
                }
                else if (instruction.OpCode == EnumOpCodes.LOADK && constants[(int)instruction.BC].Type == EnumTypesConstant.String)
                {
                    result.AppendLine(constants[(int)instruction.BC].String);
                }
                else if (instruction.OpCode == EnumOpCodes.CALL)
                {
                    index++;
                    break;
                }

                index++;
            }

            return result;
        }

        public void Extract()
        {
            Directory.CreateDirectory(Constants.SCRIPTS_DIRECTORY);

            foreach (var file in this.files)
            {
                logger.Info($"Extracting file {file.FullName}");

                using (var stream = File.Open(file.FullName, FileMode.Open, FileAccess.Read))
                {
                    var evbFile = new EvbFile(stream);

                    if ((evbFile == null) || (evbFile.Main == null)) { continue; }

                    var script = new StringBuilder();

                    foreach (var instruction in evbFile.Main.Instructions)
                    {
                        if ((instruction.OpCode == EnumOpCodes.GETGLOBAL) && (evbFile.Main.Constants[(int)instruction.BC].String == EvbCommon.TEXT_FUNCTION))
                        {
                            script.AppendLine("<SCRIPT:0>");
                        }
                    }

                    if (evbFile.Main.Functions == null) { continue; }

                    foreach (var function in evbFile.Main.Functions)
                    {
                        if (function.Instructions == null) { continue; }

                        script.AppendLine($"<{function.Id}>");

                        int scriptNumber = 0;
                        for (int index = 0; index < function.Instructions.Count;)
                        {
                            var instruction = function.Instructions[index];

                            if ((instruction.OpCode == EnumOpCodes.GETGLOBAL) && (function.Constants[(int)instruction.BC].String == EvbCommon.TEXT_FUNCTION))
                            {
                                script.AppendLine($"<SCRIPT:{scriptNumber}>");
                                index++;

                                script.Append(GetText(function.Instructions, function.Constants, ref index));
                                script.AppendLine($"</SCRIPT:{scriptNumber++}>");
                                script.AppendLine();
                                continue;
                            }

                            index++;
                        }

                        script.AppendLine($"</{function.Id}>");
                        script.AppendLine();

                        if (function.Functions != null && function.Functions.Any())
                        {

                        }
                    }

                    string path = Path.Combine(Constants.SCRIPTS_DIRECTORY, EvbCommon.EVB_DIRECTORY, Constants.SOURCE_LANGUAGE, $"{file.Name}.txt");

                    using (var writer = new StreamWriter(File.OpenWrite(path), Encoding.Unicode))
                    {
                        writer.Write(script);
                    }
                }
            }
        }
    }
}
