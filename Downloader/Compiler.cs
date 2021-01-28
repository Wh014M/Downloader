using Microsoft.CSharp;
using System.CodeDom.Compiler;
using System.Collections.Generic;

namespace Downloader
{
    internal class Compiler
    {
        internal void Build(string _Stub, string _Path_Save)
        {
            using (CSharpCodeProvider _CSharp_Code_Provider = new CSharpCodeProvider(new Dictionary<string, string> { { "CompilerVersion", "v4.0" } }))
            {
                string[] _Referenced_Assemblies = new string[]
                {
                    "System.dll",
                    "System.Core.dll",
                };

                CompilerParameters _Compiler_Parameters = new CompilerParameters(_Referenced_Assemblies)
                {
                    GenerateExecutable = true,
                    OutputAssembly = _Path_Save,
                    CompilerOptions = "/target:winexe /platform:x86 /optimize+",
                    TreatWarningsAsErrors = false,
                    IncludeDebugInformation = false,
                };
                _CSharp_Code_Provider.CompileAssemblyFromSource(_Compiler_Parameters, _Stub);
            }
        }
    }
}