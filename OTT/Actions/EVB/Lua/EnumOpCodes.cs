// <copyright file="EnumOpCodes.cs" company="BahaBulle">
//     Copyright (c) BahaBulle. All rights reserved.
// </copyright>

namespace OTT.Actions.EVB
{
    public enum EnumOpCodes : int
    {
        MOVE = 0x00,
        LOADK = 0x01,
        LOADBOOL = 0x02,
        LOADNIL = 0x03,
        GETUPVAL = 0x04,
        GETGLOBAL = 0x05,
        GETTABLE = 0x06,
        SETGLOBAL = 0x07,
        SETUPVAL = 0x08,
        SETTABLE = 0x09,
        NEWTABLE = 0x0A,
        SELF = 0x0B,
        ADD = 0x0C,
        SUB = 0x0D,
        MUL = 0x0E,
        DIV = 0x0F,
        MOD = 0x10,
        POW = 0x11,
        UNM = 0x12,
        NOT = 0x13,
        LEN = 0x14,
        CONCAT = 0x15,
        JMP = 0x16,
        EQ = 0x17,
        LT = 0x18,
        LE = 0x19,
        TEST = 0x1A,
        TESTSET = 0x1B,
        CALL = 0x1C,
        TAILCALL = 0x1D,
        RETURN = 0x1E,
        FORLOOP = 0x1F,
        FORPREP = 0x20,
        TFORLOOP = 0x21,
        SETLIST = 0x22,
        CLOSE = 0x23,
        CLOSURE = 0x24,
        VARARG = 0x25,
    }
}
