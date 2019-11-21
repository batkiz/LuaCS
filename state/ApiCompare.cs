using System;
using LuaCS.api;
using CompareOp = System.Int32;

namespace LuaCS.state
{
    public partial struct LuaState
    {
        public bool Compare(int idx1, int idx2, CompareOp op)
        {
            var a = stack.get(idx1);
            var b = stack.get(idx2);
            switch (op)
            {
                case Consts.LUA_OPEQ:
                    return _eq(a, b);
                case Consts.LUA_OPLT:
                    return _lt(a, b);
                case Consts.LUA_OPLE:
                    return _le(a, b);
                default:
                    throw new Exception("invalid compare op!");
            }
        }

        bool _eq(LuaValue a, LuaValue b)
        {
            if (a == null)
                return b == null;

            switch (a.value.GetType().Name)
            {
                case "Boolean":
                    if (b.value.GetType() == typeof(bool))
                    {
                        return a.value == b.value;
                    }
                    return false;
                case "String":
                    if (b.value.GetType() == typeof(string))
                    {
                        return a.value.ToString() == b.value.ToString();
                    }
                    return false;
                case "Int64":
                    return b.value.GetType().Name switch
                    {
                        "Int64" => (long)a.value == (long)b.value,
                        "Double" => (double)a.value == (double)b.value,
                        _ => false
                    };
                case "Double":
                    return b.value.GetType().Name switch
                    {
                        "Int64" => (double)a.value == (double)b.value,
                        "Double" => (double)a.value == (double)b.value,
                        _ => false
                    };
                default:
                    return a.value == b.value;
            }
        }

        private bool _lt(LuaValue a, LuaValue b)
        {
            switch (a.value.GetType().Name)

            {
                case "String":
                    if (b.value is string)
                    {
                        return string.Compare((string)a.value, (string)b.value) < 0;
                    }
                    throw new Exception("comparison error!");
                case "Int64":
                    return b.value.GetType().Name switch
                    {
                        "Int64" => (long)a.value < (long)b.value,
                        "Double" => (double)a.value < (double)b.value,
                        _ => throw new Exception("comparison error!"),
                    };
                case "Double":
                    return b.value.GetType().Name switch
                    {
                        "Int64" => (double)a.value < (double)b.value,
                        "Double" => (double)a.value < (double)b.value,
                        _ => throw new Exception("comparison error!"),
                    };
                default:
                    throw new Exception("comparison error!");
            }
        }

        private bool _le(LuaValue a, LuaValue b)
        {
            switch (a.value.GetType().Name)
            {
                case "String":
                    if (b.value is string)
                    {
                        return string.Compare((string)a.value, (string)b.value) <= 0;
                    }
                    throw new Exception("comparison error!");
                case "Int64":
                    return b.value.GetType().Name switch
                    {
                        "Int64" => (long)a.value <= (long)b.value,
                        "Double" => (double)a.value <= (double)b.value,
                        _ => throw new Exception("comparison error!")
                    };
                case "Double":
                    return b.value.GetType().Name switch
                    {
                        "Int64" => (double)a.value <= (double)b.value,
                        "Double" => (double)a.value <= (double)b.value,
                        _ => throw new Exception("comparison error!")

                    };
                default:
                    throw new Exception("comparison error!");
            }
        }
    }
}
