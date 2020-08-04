using Parser;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Tokenizer;

namespace CodeGenerator
{
    class Emitter
    {

        public Emitter()
        {

        }

        public void EmitGloriousExe(SyntaxTree ast)
        {
            //boiler plate
            var assemblyName = new AssemblyName("MyAssembly");
            var assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.RunAndSave);
            var moduleBuilder = assemblyBuilder.DefineDynamicModule("MainModule", "Glorious.exe");
            var typeBuilder = moduleBuilder.DefineType("Program");
            var methodBuilder = typeBuilder.DefineMethod("Main", MethodAttributes.Static);
            var ilGenerator = methodBuilder.GetILGenerator();

            emitInstructions((Expression)ast.Head);
            void emitInstructions(Expression currNode)
            {
                if (currNode.GetType() == typeof(NumericLiteralExpression))
                {
                    ilGenerator.Emit(OpCodes.Ldc_I4, int.Parse(currNode.Token.Lexeme));
                }
                else
                {
                    foreach (var child in currNode.Children)
                    {
                        emitInstructions(child);
                    }
                    if(currNode.Token.SpecificTokenType == SpecificTokenType.Add)
                    {

                    }
                    else if(currNode.Token.SpecificTokenType == SpecificTokenType.Minus)
                    {

                    }
                    else if(currNode.Token.SpecificTokenType == SpecificTokenType.Multiply)
                    {

                    }
                    else if(currNode.Token.SpecificTokenType == SpecificTokenType.Divide)
                    {

                    }
                }
            }

            typeBuilder.CreateType();
            assemblyBuilder.SetEntryPoint(methodBuilder as MethodInfo);
            assemblyBuilder.Save("Glorious.exe");
        }
    }
}
