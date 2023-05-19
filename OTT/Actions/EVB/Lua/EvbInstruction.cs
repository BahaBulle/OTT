// <copyright file="EvbInstruction.cs" company="BahaBulle">
//     Copyright (c) BahaBulle. All rights reserved.
// </copyright>

namespace OTT.Actions.EVB
{
    internal class EvbInstruction
    {
        public EvbInstruction(ulong value)
        {
            this.Value = value;

            this.Code = value & 0x3F;
            this.A = (value >> 6) & 0xFF;
            this.B = (value >> (6 + 8 + 9)) & 0x1FF;
            this.C = (value >> (6 + 8)) & 0x1FF;
            this.BC = value >> (6 + 8);
        }

        public ulong A { get; private set; }

        public ulong B { get; private set; }

        public ulong BC { get; private set; }

        public ulong C { get; private set; }

        public ulong Code { get; private set; }

        public EnumOpCodes OpCode => (EnumOpCodes)this.Code;

        public ulong Value { get; private set; }
    }
}
