using System;
using System.Collections.Immutable;

namespace CSharpCompilerStrictModeConsoleApp
{

    /// https://twitter.com/vcsjones/status/1023558048697249792
    /// https://www.meziantou.net/csharp-compiler-strict-mode.htm
    /// 
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public static void TestIntPtrOrGuidCheckNull()
        {
            IntPtr ptr = IntPtr.Zero;
            if (ptr == null)
            { }

            Guid guid = Guid.NewGuid();
            if (guid == null)
            {

            }
            // Warning CS8073 The result of the expression is always 'false' since a value of type 'IntPtr' is never equal to 'null' of type 'IntPtr?'
            //https://github.com/dotnet/coreclr/pull/19191
        }

        public static void TestLockNull()
        {
            lock (null) // Error CS0185 '<null>' is not a reference type as required by the lock statement
            {
            }
        }

        static class Foo { }
        public static void TestIsOrAsOperatorCanNotUsedWithStaticType()
        {
            var o = new object();
            if (o is Math) // Error CS7023 The second operand of an 'is' or 'as' operator may not be static type 'Math'
            {
            }

            (o as Foo).ToString();            

        }


        enum Color { Black, Yellow, Red, White }
        public static void TestMinusOperatorWithEnum()
        {
            _ = 1 - Color.Red; // Error CS0019: Operator '-' cannot be applied to operands of type 'int' and 'Color'
        }

        public static void TestDelegateFunctionName()
        {
            var func = new Func<string, string>(x => x);
            _ = new Func<string, string>(ref func); // Error CS0149: Method name expected
        }

        public static void TestImmutableArrayTypeInitialization(out ImmutableArray<string> result) // Error CS0177: The out parameter 'result' must be assigned to before control leaves the current method
        {
        }

        // For more information: https://github.com/dotnet/roslyn/issues/13203


    }
}
