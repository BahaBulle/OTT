// <copyright file="EvbConstant.cs" company="BahaBulle">
//     Copyright (c) BahaBulle. All rights reserved.
// </copyright>

namespace OTT.Actions.EVB
{
    internal class EvbConstant
    {
        public EvbConstant(bool value)
        {
            this.Type = EnumTypesConstant.Bool;
            this.Bool = value;
        }

        public EvbConstant(double value)
        {
            this.Type = EnumTypesConstant.Number;
            this.Double = value;
        }

        public EvbConstant(string? value)
        {
            this.Type = EnumTypesConstant.String;
            this.String = value;
        }
        public EvbConstant(string? value, byte[]? data)
        {
            this.Type = EnumTypesConstant.String;
            this.String = value;
            this.Data = data;
        }

        public bool? Bool { get; private set; }

        public byte[]? Data { get; private set; }

        public double? Double { get; private set; }

        public bool IsNil => !this.Bool.HasValue && !this.Double.HasValue && this.String != null;

        public string? String { get; private set; }

        public EnumTypesConstant Type { get; private set; }
    }
}
