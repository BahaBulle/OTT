// <copyright file="EvbFile.cs" company="BahaBulle">
//     Copyright (c) BahaBulle. All rights reserved.
// </copyright>

namespace OTT.Actions.EVB
{
    using System.IO;

    internal class EvbFile
    {
        private readonly Stream source;

        internal EvbFile(Stream source)
        {
            this.source = source;

            using (var binaryReader = new BinaryReader(this.source))
            {
                if (binaryReader.BaseStream.Length < 12)
                {
                    throw new EvbException("Not a correct EVB file : size");
                }

                this.Header = new EvbHeader(binaryReader);
                this.Main = new EvbFunction(binaryReader, this.Header, "Main");
            }
        }

        internal EvbHeader? Header { get; set; }

        internal EvbFunction? Main { get; set; }
    }
}
