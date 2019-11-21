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

        internal static (double, bool) convertToFloat(LuaValue val)
        {
            return val.value.GetType().Name switch
            {
                "Double" => ((double)val.value, true),
                "Int64" => (Convert.ToDouble(val.value), true),
                "String" => number.Parser.ParseFloat((string)val.value),
                _ => (0, false)
            };
        }

        internal static (long, bool) convertToInteger(LuaValue val)
        {
            return val.value.GetType().Name switch
            {
                "Int64" => ((long)val.value, true),
                "Double" => number.Math.FloatToInteger((double)val.value),
                "String" => _stringToInteger((string)val.value),
                _ => (0, false)
            };
        }

        private static (long, bool) _stringToInteger(string s)
        {
            var (i, ok) = number.Parser.ParseInteger(s);
            if (ok)
            {
                return (i, true);
            }
            var (f, ok2) = number.Parser.ParseFloat(s);
            if (ok2)
            {
                return number.Math.FloatToInteger(f);
            }

            return (0, false);
        }
    }
}
