using LuaCS.api;
using System;
using LuaType = System.Int32;

namespace LuaCS.state
{
    public partial struct LuaState
    {
        public string TypeName(LuaType tp)
        {
            return (tp) switch
            {
                Consts.LUA_TNONE => "no value",
                Consts.LUA_TNIL => "nil",
                Consts.LUA_TBOOLEAN => "boolean",
                Consts.LUA_TNUMBER => "number",
                Consts.LUA_TSTRING => "string",
                Consts.LUA_TTABLE => "table",
                Consts.LUA_TFUNCTION => "function",
                Consts.LUA_TTHREAD => "thread",
                _ => "userdata"
            };
        }

        public LuaType Type(int idx)
        {
            if (stack.isValid(idx))
            {
                var val = stack.get(idx);
                return LuaValue.typeOf(val);
            }
            return Consts.LUA_TNONE;
        }

        public bool IsNone(int idx)
        {
            return Type(idx) == Consts.LUA_TNONE;
        }

        public bool IsNil(int idx)
        {
            return Type(idx) == Consts.LUA_TNIL;
        }

        public bool IsNoneOrNil(int idx)
        {
            return Type(idx) <= Consts.LUA_TNIL;
        }

        public bool IsBoolean(int idx)
        {
            return Type(idx) == Consts.LUA_TBOOLEAN;
        }

        public bool IsString(int idx)
        {
            var t = Type(idx);
            return t == Consts.LUA_TSTRING || t == Consts.LUA_TNUMBER;
        }

        public (double, bool) ToNumberX(int idx)
        {
            var val = stack.get(idx);
            return LuaValue.convertToFloat(val);
        }

        public double ToNumber(int idx)
        {
            var (n, _) = ToNumberX(idx);
            return n;
        }

        public bool IsNumber(int idx)
        {
            var (_, ok) = ToNumberX(idx);
            return ok;
        }

        public bool IsInteger(int idx)
        {
            var val = stack.get(idx);
            return val.value.GetType() == typeof(long);
        }

        public bool ToBoolean(int idx)
        {
            var val = stack.get(idx);
            return LuaValue.convertToBoolean(val);
        }

        public long ToInteger(int idx)
        {
            var (i, _) = ToIntegerX(idx);
            return i;
        }

        public (long, bool) ToIntegerX(int idx)
        {
            var val = stack.get(idx);
            return LuaValue.convertToInteger(val);
        }

        public (string, bool) ToStringX(int idx)
        {
            var val = stack.get(idx);
            switch (val.value.GetType().Name)
            {
                case "String":
                    return ((string)val.value, true);
                case "Int64":
                case "Double":
                    var s = val;
                    stack.set(idx, s);
                    return (s.value.ToString(), true);
                default:
                    return ("", false);
            }
        }

        public string ToString(int idx)
        {
            var (s, _) = ToStringX(idx);
            return s;
        }
    }
}
