// <copyright file="ExtractArguments.cs" company="BahaBulle">
//     Copyright (c) BahaBulle. All rights reserved.
// </copyright>

namespace OTT
{
    using System.Collections.Generic;
    using CommandLine;

    [Verb("extract", false, new string[] { "e" }, HelpText = "Extract data")]
    public class ExtractArguments : IExtractArguments
    {
        [Option('d', "directory", Required = true, HelpText = "Path of a directory that contains files to process")]
        public string Directory { get; set; } = string.Empty;

        [Option('f', "filenames", Required = false, HelpText = "Names of files to extract separated by semicolons (;)")]
        public string FileNames { get; set; } = string.Empty;

        public IEnumerable<string> FilesList => string.IsNullOrWhiteSpace(this.FileNames) ? (new List<string>()) : this.FileNames.Split(new char[] { ';' });

        [Option('t', "type", Default = EnumFileTypes.ALL, Required = false, HelpText = "Type of files to extract")]
        public EnumFileTypes FileType { get; set; }
    }
}