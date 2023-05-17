// <copyright file="FilesHelper.cs" company="BahaBulle">
//     Copyright (c) BahaBulle. All rights reserved.
// </copyright>

namespace OTT.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using NLog;

    public static class FilesHelper
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        public static IEnumerable<FileInfo> GetFiles(string directory, IEnumerable<string> filesList, string extension)
        {
            logger.Trace($"Start GetFiles({directory}, {filesList.Count()}, {extension})");

            var result = new List<FileInfo>();

            if (!Directory.Exists(directory))
            {
                logger.Error($"Directory not found : {directory}");
                return result;
            }

            var directoryInfos = new DirectoryInfo(directory);

            var files = directoryInfos.GetFiles($"*{extension}", SearchOption.AllDirectories);

            if (filesList.Any())
            {
                result.AddRange(files.Where(x => filesList.Contains(x.Name)));
            }
            else
            {
                result.AddRange(files);
            }

            logger.Debug($"Found {result.Count} file(s)");

            return result;
        }
    }
}
