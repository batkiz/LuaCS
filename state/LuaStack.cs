using System;

namespace LuaCS.state
{
    public class LuaStack
    {
        private LuaValue[] slots;
        internal int top;

        internal static LuaStack newLuaStack(int size)
        {
            return new LuaStack { slots = new LuaValue[size], top = 0 };
        }

        internal void check(int n)
        {
            var free = slots.Length - top;
            if (n <= free) return;
            var newSlots = new LuaValue[top + n];
            Array.Copy(slots, newSlots, slots.Length);
            slots = newSlots;
        }

        internal void push(LuaValue val)
        {
            if (top == slots.Length)
            {
                throw new Exception("stack overflow!");
            }
            slots[top] = val;
            top++;
        }

        internal LuaValue pop()
        {
            if (top < 1)
            {
                throw new Exception("stack underflow!");
            }
            top--;
            var val = slots[top];
            slots[top] = null;
            return val;
        }

        internal int absIndex(int idx)
        {
            if (idx > 0)
            {
                return idx;
            }
            return idx + top + 1;
        }

        internal LuaValue get(int idx)
        {
            var absIdx = absIndex(idx);
            if (absIdx > 0 && absIdx <= top)
            {
                return slots[absIdx - 1];
            }
            return null;
        }

        internal void set(int idx, LuaValue val)
        {
            var absIdx = absIndex(idx);
            if (absIdx > 0 && absIdx <= top)
            {
                slots[absIdx - 1] = val;
                return;
            }
            throw new Exception("invalid index!");
        }

        internal void reverse(int from, int to)
        {
            while (from < to)
            {
                (slots[from], slots[to]) = (slots[to], slots[from]);
                from++;
                to--;
            }
        }

        internal bool isValid(int idx)
        {
            var absIdx = absIndex(idx);
            return absIdx >0&&absIdx<=top;
        }
    }
}
