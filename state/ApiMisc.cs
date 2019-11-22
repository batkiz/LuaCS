using System;

namespace LuaCS.state
{
    public partial struct LuaState
    {
        public void Len(int idx)
        {
            var val = stack.get(idx);
            if (val.value is string s)
            {
                stack.push(new LuaValue((long)s.Length));
            }
            else
            {
                throw new Exception("length error!");
            }
        }

        public void Contact(int n)
        {
            if (n == 0)
            {
                stack.push(new LuaValue(""));
            }
            else if (n >= 2)
            {
                for (var i = 1; i < n; i++)
                {
                    if (IsString(-1) && IsString(-2))
                    {
                        var s2 = ToString(-1);
                        var s1 = ToString(-2);
                        stack.pop();
                        stack.pop();
                        stack.push(new LuaValue(s1 + s2));
                        continue;
                    }
                    throw new Exception("concatenation error!");
                }
            }
            // n==1, do nothing
        }
    }
}
