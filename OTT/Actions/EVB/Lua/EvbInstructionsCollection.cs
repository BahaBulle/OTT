// <copyright file="EvbInstructionsCollection.cs" company="BahaBulle">
//     Copyright (c) BahaBulle. All rights reserved.
// </copyright>

namespace OTT.Actions.EVB
{
    using System.Collections.ObjectModel;
    using System.IO;

    internal class EvbInstructionsCollection : Collection<EvbInstruction>
    {
        internal EvbInstructionsCollection(BinaryReader binaryReader, EvbHeader header)
        {
            ulong numberOfElement = EvbHelper.ReadInteger(binaryReader, header.IsLittleEndian, header.SizeOfInt);

            for (ulong i = 0; i < numberOfElement; i++)
            {
                var instruction = new EvbInstruction(EvbHelper.ReadInteger(binaryReader, header.IsLittleEndian, header.SizeOfInstruction));

                this.Add(instruction);
            }
        }
    }
}
