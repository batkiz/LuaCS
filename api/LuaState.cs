using ArithOp = System.Int32;
using CompareOp = System.Int32;
using LuaType = System.Int32;

namespace LuaCS.api
{
    public partial interface LuaState
    {
        /* basic stack manipulation */
        int GetTop();
        int AbsIndex(int idx);
        bool CheckStack(int n);
        void Pop(int n);
        void Copy(int fromIdx, int toIdx);
        void PushValue(int idx);
        void Replace(int idx);
        void Insert(int idx);
        void Remove(int idx);
        void Rotate(int idx, int n);
        void SetTop(int idx);

        /* access functions (stack -> c#) */
        string TypeName(LuaType tp);
        LuaType Type(int idx);
        bool IsNone(int idx);
        bool IsNil(int idx);
        bool IsNoneOrNil(int idx);
        bool IsBoolean(int idx);
        bool IsInteger(int idx);
        bool IsNumber(int idx);
        bool IsString(int idx);
        bool ToBoolean(int idx);
        long ToInteger(int idx);
        (long, bool) ToIntegerX(int idx);
        double ToNumber(int idx);
        (double, bool) ToNumberX(int idx);
        string ToString(int idx);
        (string, bool) ToStringX(int idx);

        /* push functions (c# -> stack) */
        void PushNil();
        void PushBoolean(bool b);
        void PushInteger(long n);
        void PushNumber(double n);
        void PushString(string s);

        void Arith(ArithOp op);
        bool Compare(int idx1, int idx2, CompareOp op);
        void Len(int idx);
        void Contact(int n);
    }
}
