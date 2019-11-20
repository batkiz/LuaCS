using LuaCS.api;
using System;
using LuaType = System.Int32;

namespace LuaCS.state
{
    public class LuaValue
    {
        internal readonly object value;

        public LuaValue(object value)
        {
            this.value = value;
        }

        internal static LuaType typeOf(LuaValue val)
        {
            if (val == null)
            {
                return Consts.LUA_TNIL;
            }

            switch (val.value.GetType().Name)
            {
                case "Boolean": return Consts.LUA_TBOOLEAN;
                case "Int64": return Consts.LUA_TNUMBER;
                case "Double": return Consts.LUA_TNUMBER;
                case "String": return Consts.LUA_TSTRING;
                default: throw new Exception("todo!");
            }
        }

        internal static bool convertToBoolean(LuaValue val)
        {
            if (val == null)
            {
                return false;
            }

            return val.value.GetType().Name switch
            {
                "Boolean" => (bool)val.value,
                _ => true
            };
        }
    }
}
