namespace LuaCS.vm
{
    public static class OpCodes
    {
        internal const byte IABC = 0;
        internal const byte IABx = 1;
        internal const byte IAsBx = 2;
        internal const byte IAx = 3;

        internal const byte OP_MOVE = 0;
        internal const byte OP_LOADK = 1;
        internal const byte OP_LOADKX = 2;
        internal const byte OP_LOADBOOL = 3;
        internal const byte OP_LOADNIL = 4;
        internal const byte OP_GETUPVAL = 5;
        internal const byte OP_GETTABUP = 6;
        internal const byte OP_GETTABLE = 7;
        internal const byte OP_SETTABUP = 8;
        internal const byte OP_SETUPVAL = 9;
        internal const byte OP_SETTABLE = 10;
        internal const byte OP_NEWTABLE = 11;
        internal const byte OP_SELF = 12;
        internal const byte OP_ADD = 13;
        internal const byte OP_SUB = 14;
        internal const byte OP_MUL = 15;
        internal const byte OP_MOD = 16;
        internal const byte OP_POW = 17;
        internal const byte OP_DIV = 18;
        internal const byte OP_IDIV = 19;
        internal const byte OP_BAND = 20;
        internal const byte OP_BOR = 21;
        internal const byte OP_BXOR = 22;
        internal const byte OP_SHL = 23;
        internal const byte OP_SHR = 24;
        internal const byte OP_UNM = 25;
        internal const byte OP_BNOT = 26;
        internal const byte OP_NOT = 27;
        internal const byte OP_LEN = 28;
        internal const byte OP_CONCAT = 29;
        internal const byte OP_JMP = 30;
        internal const byte OP_EQ = 31;
        internal const byte OP_LT = 32;
        internal const byte OP_LE = 33;
        internal const byte OP_TEST = 34;
        internal const byte OP_TESTSET = 35;
        internal const byte OP_CALL = 36;
        internal const byte OP_TAILCALL = 37;
        internal const byte OP_RETURN = 38;
        internal const byte OP_FORLOOP = 39;
        internal const byte OP_FORPREP = 40;
        internal const byte OP_TFORCALL = 41;
        internal const byte OP_TFORLOOP = 42;
        internal const byte OP_SETLIST = 43;
        internal const byte OP_CLOSURE = 44;
        internal const byte OP_VARARG = 45;
        internal const byte OP_EXTRAARG = 46;

        internal const byte OpArgN = 0;
        internal const byte OpArgU = 1;
        internal const byte OpArgR = 2;
        internal const byte OpArgK = 3;

        internal static opcode[] opcodes =
        {
            /*         T  A  B       C       mode  name      */
            new opcode(0, 1, OpArgR, OpArgN, IABC, "MOVE    "),
            new opcode(0, 1, OpArgK, OpArgN, IABx, "LOADK   "),
            new opcode(0, 1, OpArgN, OpArgN, IABx, "LOADKX  "),
            new opcode(0, 1, OpArgU, OpArgU, IABC, "LOADBOOL"),
            new opcode(0, 1, OpArgU, OpArgN, IABC, "LOADNIL "),
            new opcode(0, 1, OpArgU, OpArgN, IABC, "GETUPVAL"),
            new opcode(0, 1, OpArgU, OpArgK, IABC, "GETTABUP"),
            new opcode(0, 1, OpArgR, OpArgK, IABC, "GETTABLE"),
            new opcode(0, 0, OpArgK, OpArgK, IABC, "SETTABUP"),
            new opcode(0, 0, OpArgU, OpArgN, IABC, "SETUPVAL"),
            new opcode(0, 0, OpArgK, OpArgK, IABC, "SETTABLE"),
            new opcode(0, 1, OpArgU, OpArgU, IABC, "NEWTABLE"),
            new opcode(0, 1, OpArgR, OpArgK, IABC, "SELF    "),
            new opcode(0, 1, OpArgK, OpArgK, IABC, "ADD     "),
            new opcode(0, 1, OpArgK, OpArgK, IABC, "SUB     "),
            new opcode(0, 1, OpArgK, OpArgK, IABC, "MUL     "),
            new opcode(0, 1, OpArgK, OpArgK, IABC, "MOD     "),
            new opcode(0, 1, OpArgK, OpArgK, IABC, "POW     "),
            new opcode(0, 1, OpArgK, OpArgK, IABC, "DIV     "),
            new opcode(0, 1, OpArgK, OpArgK, IABC, "IDIV    "),
            new opcode(0, 1, OpArgK, OpArgK, IABC, "BAND    "),
            new opcode(0, 1, OpArgK, OpArgK, IABC, "BOR     "),
            new opcode(0, 1, OpArgK, OpArgK, IABC, "BXOR    "),
            new opcode(0, 1, OpArgK, OpArgK, IABC, "SHL     "),
            new opcode(0, 1, OpArgK, OpArgK, IABC, "SHR     "),
            new opcode(0, 1, OpArgR, OpArgN, IABC, "UNM     "),
            new opcode(0, 1, OpArgR, OpArgN, IABC, "BNOT    "),
            new opcode(0, 1, OpArgR, OpArgN, IABC, "NOT     "),
            new opcode(0, 1, OpArgR, OpArgN, IABC, "LEN     "),
            new opcode(0, 1, OpArgR, OpArgR, IABC, "CONCAT  "),
            new opcode(0, 0, OpArgR, OpArgN, IAsBx, "JMP     "),
            new opcode(1, 0, OpArgK, OpArgK, IABC, "EQ      "),
            new opcode(1, 0, OpArgK, OpArgK, IABC, "LT      "),
            new opcode(1, 0, OpArgK, OpArgK, IABC, "LE      "),
            new opcode(1, 0, OpArgN, OpArgU, IABC, "TEST    "),
            new opcode(1, 1, OpArgR, OpArgU, IABC, "TESTSET "),
            new opcode(0, 1, OpArgU, OpArgU, IABC, "CALL    "),
            new opcode(0, 1, OpArgU, OpArgU, IABC, "TAILCALL"),
            new opcode(0, 0, OpArgU, OpArgN, IABC, "RETURN  "),
            new opcode(0, 1, OpArgR, OpArgN, IAsBx, "FORLOOP "),
            new opcode(0, 1, OpArgR, OpArgN, IAsBx, "FORPREP "),
            new opcode(0, 0, OpArgN, OpArgU, IABC, "TFORCALL"),
            new opcode(0, 1, OpArgR, OpArgN, IAsBx, "TFORLOOP"),
            new opcode(0, 0, OpArgU, OpArgU, IABC, "SETLIST "),
            new opcode(0, 1, OpArgU, OpArgN, IABx, "CLOSURE "),
            new opcode(0, 1, OpArgU, OpArgN, IABC, "VARARG  "),
            new opcode(0, 0, OpArgU, OpArgU, IAx, "EXTRAARG"),
        };
    }

    internal struct opcode
    {
        internal byte testFlag;
        internal byte setAFlag;
        internal byte argBMode;
        internal byte argCMode;
        internal byte opMode;
        internal string name;

        public opcode(byte TestFlag, byte aFlag, byte ArgBMode, byte ArgCMode, byte OpMode, string Name)
        {
            testFlag = TestFlag;
            setAFlag = aFlag;
            argBMode = ArgBMode;
            argCMode = ArgCMode;
            opMode = OpMode;
            name = Name;
        }
    }


}
