// <copyright file="EVBExtracter.cs" company="BahaBulle">
//     Copyright (c) BahaBulle. All rights reserved.
// </copyright>

namespace OTT.Actions.EVB
{
    using NLog;

    public class EVBExtracter
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        private readonly IEnumerable<FileInfo> files;

        public EVBExtracter(IEnumerable<FileInfo> files)
        {
            this.files = files;
        }

        public void Extract()
        {
            foreach (var file in this.files)
            {
                logger.Info($"Extracting file {file.FullName}");

                using (var stream = File.Open(file.FullName, FileMode.Open, FileAccess.Read))
                {
                    var evbFile = new EvbFile(stream);


                }
            }
        }
    }
}
