using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;

namespace ConsoleAppMath
{

    internal class Program
    {
        static async Task Main(string[] args)
        {
            while (true)
            {
                Console.Write("Enter an arithmetic expression -> ");
                string input = Console.ReadLine();

                if (input?.ToLower() == "exit")
                    break;

                try
                {
                    var options = ScriptOptions.Default.AddReferences(typeof(Math).Assembly).AddImports("System", "System.Math");

                    var result = await CSharpScript.EvaluateAsync(input, options);
                    Console.WriteLine($"Resolt: {result}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
    }
}