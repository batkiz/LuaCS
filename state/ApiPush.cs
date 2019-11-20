namespace LuaCS.state
{
    public partial struct LuaState
    {
        public void PushNil()
        {
            stack.push(null);
        }

        public void PushBoolean(bool b)
        {
            stack.push(new LuaValue(b));
        }

        public void PushInteger(long n)
        {
            stack.push(new LuaValue(n));
        }

        public void PushNumber(double n)
        {
            stack.push(new LuaValue(n));
        }

        public void PushString(string s)
        {
            stack.push(new LuaValue(s));
        }
    }
}
