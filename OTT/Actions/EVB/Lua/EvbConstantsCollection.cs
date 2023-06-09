﻿// <copyright file="EvbConstantsCollection.cs" company="BahaBulle">
//     Copyright (c) BahaBulle. All rights reserved.
// </copyright>

namespace OTT.Actions.EVB
{
    using System.Collections.ObjectModel;
    using System.IO;

    internal class EvbConstantsCollection : Collection<EvbConstant>
    {
        public EvbConstantsCollection(BinaryReader binaryReader, EvbHeader header)
        {
            ulong numberOfElement = EvbHelper.ReadInteger(binaryReader, header.IsLittleEndian, header.SizeOfInt);

            for (ulong i = 0; i < numberOfElement; i++)
            {
                byte type = binaryReader.ReadByte();

                EvbConstant? constant = null;
                switch (type)
                {
                    case 1:
                        constant = new EvbConstant(binaryReader.ReadBoolean());
                        break;

                    case 3:
                        constant = new EvbConstant(EvbHelper.ReadNumber(binaryReader, header.SizeOfLuaNumber));
                        break;

                    case 4:
                        (var value, var data) = EvbHelper.ReadStringBinary(binaryReader, header.IsLittleEndian, header.SizeOfInt);
                        constant = new EvbConstant(value, data);
                        break;
                }

                if (constant != null)
                {
                    this.Add(constant);
                }
            }
        }
    }
}
