using System;
using System.Collections.Generic;
using System.Text;

namespace LuaCS.number
{
    class Parser
    {
        internal static (long, bool) ParseInteger(string str)
        {
            try
            {
                var i = Convert.ToInt64(str);
                return (i, true);
            }
            catch (Exception)
            {
                return (0, false);
            }
        }

        internal static (double, bool) ParseFloat(string str)
        {
            try
            {
                var i = Convert.ToDouble(str);
                return (i, true);
            }
            catch (Exception)
            {
                return (0, false);
            }
        }
    }
}
