namespace LuaCS.state
{
    public partial struct LuaState : api.LuaState
    {
        private LuaStack stack;

        public static LuaState New()
        {
            return new LuaState
            {
                stack = LuaStack.newLuaStack(20)
            };
        }
    }
}
