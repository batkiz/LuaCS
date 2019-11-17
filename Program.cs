using System;
using System.IO;
using LuaCS.binchunk;

namespace LuaCS
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length <= 0) return;
            try
            {
                var fs = File.OpenRead(args[0]);
                var data = new byte[fs.Length];
                fs.Read(data, 0, data.Length);
                var proto = BinaryChunk.Undump(data);
                list(proto);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        static void list(Prototype f)
        {
            printHeader(f);
            printCode(f);
            printDetail(f);
            foreach (var p in f.Protos)
            {
                list(p);
            }
        }

        static void printHeader(Prototype f)
        {
            var funcType = "main";
            if (f.LineDefined > 0)
            {
                funcType = "funtion";
            }


            var varargFlag = "";
            if (f.IsVararg > 0)
            {
                varargFlag = "+";
            }

            Console.Write($"\n{funcType} <{f.Source}:{f.LineDefined},{f.LastLineDefined}> ({f.Code.Length} instructions)\n");

            Console.Write($"{f.NumParams}{varargFlag} params, {f.MaxStackSize} slots, {f.Upvalues.Length} upvalues, ");

            Console.Write($"{f.LocVars.Length} locals, {f.Constants.Length} constants, {f.Protos.Length} functions\n");
        }

        static void printCode(Prototype f)
        {
            for (var pc = 0; pc < f.Code.Length; pc++)
            {
                var c = f.Code[pc];

                var line = "-";
                if (f.LineInfo.Length > 0)
                {
                    line = f.LineInfo[pc].ToString();
                }
                Console.Write($"\t{pc + 1}\t[{line}]\t0x{c:x8}\n");
            }
        }

        static void printDetail(Prototype f)
        {
            Console.Write($"constants ({f.Constants.Length}):\n");
            for (int i = 0; i < f.Constants.Length; i++)
            {
                Console.Write($"\t{i + 1}\t\"{constantToString(f.Constants[i])}\"\n");
            }

            Console.Write($"locals ({f.LocVars.Length}):\n");
            for (int i = 0; i < f.LocVars.Length; i++)
            {
                Console.Write($"\t{i}\t{f.LocVars[i].VarName}\t{f.LocVars[i].StartPC + 1}\t{f.LocVars[i].EndPC + 1}");
            }

            Console.Write($"upvalues ({f.Upvalues.Length}):\n");
            for (int i = 0; i < f.Upvalues.Length; i++)
            {
                Console.Write($"\t{i}\t{upvalName(f, i)}\t{f.Upvalues[i].Instack}\t{f.Upvalues[i].Idx}");
            }
        }

        static string constantToString(object k)
        {
            if (k == null)
            {
                return "nil";
            }

            return k.GetType().Name switch
            {
                "Boolean" => ((bool)k).ToString(),
                "Double" => ((double)k).ToString(),
                "Long" => ((long)k).ToString(),
                "String" => (string)k,
                _ => "?",
            };
        }

        static string upvalName(Prototype f, int idx)
        {
            return f.UpvalueNames.Length > 0 ? f.UpvalueNames[idx] : "-";
        }
    }
}
