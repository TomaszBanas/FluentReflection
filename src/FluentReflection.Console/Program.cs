using FluentReflection.Core.Extensions;
using Newtonsoft.Json;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace FluentReflection.Core
{
    public static class TestStatic
    {
        public static int Id { get; set; }
        public static string? Name { get; set; } = default;

        public static async Task<string> SaySomethingAsync(string toWho)
        {
            await Task.Delay(1000);
            Console.WriteLine(toWho);
            return "ho ho";
        }

        public static void SaySomething(string toWho)
        {
            Console.WriteLine(toWho);
        }

        private static void SaySomethingInternal(string toWho)
        {
            Console.WriteLine(toWho);
        }
    }

    public class TestInstance
    {
        public int Id { get; set; }
        public int Id2 { get; } = 1;
        public string? Name { get; set; } = default;

        public void SaySomething(string toWho)
        {
            Console.WriteLine(toWho);
        }

        private void SaySomethingInternal(string toWho)
        {
            Console.WriteLine(toWho);
        }
    }

    public class Program
    {
        public static async Task Main(string[] args)
        {
            var test = new TestInstance();
            var type = test.GetType();
            var fluentTest = test.AsFluentReflection();
            var json = System.Text.Json.JsonSerializer.Serialize(fluentTest);
            var jsonNS = JsonConvert.SerializeObject(fluentTest);
            var json2 = System.Text.Json.JsonSerializer.Serialize(test);

            //var methodsStatic = typeof(TestStatic).GetMethods(BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public).Where(x => !x.CustomAttributes.Any(x => x.AttributeType == typeof(CompilerGeneratedAttribute))).ToList();
            //var method = methodsStatic.First();
            //var parameters = method.GetParameters();
            //Console.WriteLine("Before");
            //var res = await (dynamic)method.Invoke(null, new object[] { "test" });
            //Console.WriteLine(res);
            //Console.WriteLine("After");
        }
    }
}