using System;
using System.Collections.Generic;
using System.Text;

namespace LuaCS.vm
{
    class Instruction
    {
        public Instruction(uint b)
        {
            self = b;
        }
        private uint self;

        public int Opcode()
        {
            return (int)(self & 0x3F);
        }

        public (int, int, int) ABC()
        {
            return ((int)(self >> 6) & 0xFF,
                    (int)(self >> 23) & 0x1FF,
                    (int)(self >> 14) & 0x1FF);
        }

        public (int, int) ABx()
        {
            return ((int)((self >> 6) & 0xFF),
                    (int)(self >> 14));
        }

        public const int MAXARG_Bx = (1 << 18) - 1; // 2^18 - 1 = 262143
        public const int MAXARG_sBx = MAXARG_Bx >> 1; // 262143 / 2 = 131071

        public (int, int) AsBx()
        {
            var (a, bx) = ABx();
            return (a, bx - MAXARG_sBx);
        }

        public int Ax()
        {
            return (int)(self >> 6);
        }

        public string OpName()
        {
            return OpCodes.opcodes[Opcode()].name;
        }

        public byte OpMode()
        {
            return OpCodes.opcodes[Opcode()].opMode;
        }

        public byte BMode()
        {
            return OpCodes.opcodes[Opcode()].argBMode;
        }

        public byte CMode()
        {
            return OpCodes.opcodes[Opcode()].argCMode;
        }
    }
}
