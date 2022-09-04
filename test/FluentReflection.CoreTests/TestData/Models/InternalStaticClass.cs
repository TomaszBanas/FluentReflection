namespace FluentReflection.TestData.TestData.Models
{
    internal static class InternalStaticClass
    {
        private static int Value { get; set; }

        private static void SetValue(int v)
        {
            Value = v;
        }

        private static int GetValue()
        {
            return Value;
        }

    }

}