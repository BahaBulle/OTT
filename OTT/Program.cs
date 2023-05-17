// <copyright file="Program.cs" company="BahaBulle">
// Copyright (c) BahaBulle. All rights reserved.
// </copyright>

namespace OTT
{
    using CommandLine;
    using CommandLine.Text;
    using NLog;
    using OTT.Actions.EVB;
    using OTT.Common;

    internal class Program
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        private static int DisplayHelp<T>(ParserResult<T> parserResult)
        {
            var helpText = HelpText.AutoBuild(
                parserResult,
                h =>
                {
                    h.AddDashesToOption = true;
                    h.AddEnumValuesToHelpText = true;
                    h.AutoHelp = false;     // hides --help
                    h.AdditionalNewLineAfterOption = false;
                    h.AutoVersion = false;  // hides --version
                    h.MaximumDisplayWidth = 200;

                    return HelpText.DefaultParsingErrorsHandler(parserResult, h);
                },
                y => y);

            logger.Info(helpText);

            return Constants.RETURN_CODE_ARGUMENTS_ERRORS;
        }

        private static int ExtractAction(IExtractArguments parameters)
        {
            try
            {
                if (parameters.FileType is EnumFileTypes.ALL or EnumFileTypes.EVB)
                {
                    var files = FilesHelper.GetFiles(parameters.Directory, parameters.FilesList, Constants.EVB_EXTENSION);

                    var extracter = new EVBExtracter(files);
                    extracter.Extract();
                }
            }
            catch (Exception ex)
            {
                logger.Fatal(ex, ex.Message);

                return Constants.RETURN_CODE_ERRORS;
            }

            return Constants.RETURN_CODE_OK;
        }

        private static int Main(string[] args)
        {
            var parser = new Parser(with => with.HelpWriter = null);
            var parserResult = parser.ParseArguments<ExtractArguments>(args);

            return parserResult.MapResult(
                (ExtractArguments extractArguments) => ExtractAction(extractArguments),
                errors => DisplayHelp(parserResult));
        }
    }
}