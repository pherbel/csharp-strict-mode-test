using HelperClassLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpCompilerStrictModeConsoleApp
{
    public class TestHelperClass
    {
        void TestUnassignedLocalVariable()
        {
            TestStruct s; // Error CS0165: Use of unassigned local variable 's' (https://github.com/dotnet/roslyn/blob/master/docs/compilers/CSharp/Definite%20Assignment.md#definite-assignment-of-structs-across-assemblies)
        }
    }
}
