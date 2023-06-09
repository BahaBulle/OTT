﻿// <copyright file="EvbHelper.cs" company="BahaBulle">
//     Copyright (c) BahaBulle. All rights reserved.
// </copyright>

namespace OTT.Actions.EVB
{
    using System;
    using System.IO;

    internal static class EvbHelper
    {
        internal static ulong ReadInteger(BinaryReader reader, bool isLittleEndian, byte intSize)
        {
            byte[] bytes = reader.ReadBytes(intSize);
            ulong ret = 0;

            if (isLittleEndian)
            {
                for (int i = 0; i < intSize; ++i)
                {
                    ret += (ulong)bytes[i] << i * 8;
                }
            }
            else
            {
                for (int i = 0; i < intSize; ++i)
                {
                    ret += (ulong)bytes[i] << (intSize - i - 1) * 8;
                }
            }

            return ret;
        }

        internal static double ReadNumber(BinaryReader reader, byte numSize)
        {
            byte[] bytes = reader.ReadBytes(numSize);
            double ret;

            if (numSize == 8)
            {
                ret = BitConverter.ToDouble(bytes, 0);
            }
            else if (numSize == 4)
            {
                ret = BitConverter.ToSingle(bytes, 0);
            }
            else
            {
                throw new NotImplementedException("Uhm...");
            }

            return ret;
        }

        internal static string? ReadString(BinaryReader reader, bool isLittleEndian, byte size)
        {
            ulong stringSize = ReadInteger(reader, isLittleEndian, size);

            if (stringSize == 0) { return null; }

            byte[] bytes = reader.ReadBytes((int)stringSize);

            char[] chars = new char[bytes.Length - 1];

            for (int i = 0; i < bytes.Length - 1; ++i)
            {
                chars[i] = (char)bytes[i];
            }

            return new string(chars);
        }

        internal static (string?, byte[]?) ReadStringBinary(BinaryReader reader, bool isLittleEndian, byte size)
        {
            ulong stringSize = ReadInteger(reader, isLittleEndian, size);

            if (stringSize == 0) { return (null, null); }

            byte[] bytes = reader.ReadBytes((int)stringSize);

            char[] chars = new char[bytes.Length - 1];

            for (int i = 0; i < bytes.Length - 1; ++i)
            {
                chars[i] = (char)bytes[i];
            }

            return (new string(chars), bytes);
        }
    }
}
