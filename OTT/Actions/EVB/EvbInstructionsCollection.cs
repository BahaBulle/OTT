// <copyright file="EvbInstructionsCollection.cs" company="BahaBulle">
//     Copyright (c) BahaBulle. All rights reserved.
// </copyright>

namespace OTT.Actions.EVB
{
    using System.Collections.ObjectModel;
    using System.IO;

    internal class EvbInstructionsCollection : Collection<ulong>
    {
        internal EvbInstructionsCollection(BinaryReader binaryReader, EvbHeader header)
        {
            ulong numberOfElement = EvbHelper.ReadInteger(binaryReader, header.IsLittleEndian, header.SizeOfInt);

            for (ulong i = 0; i < numberOfElement; i++)
            {
                ulong value = EvbHelper.ReadInteger(binaryReader, header.IsLittleEndian, header.SizeOfInstruction);

                this.Add(value);
            }
        }
    }
}
