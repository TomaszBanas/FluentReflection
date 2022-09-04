namespace FluentReflection.TestData.TestData.Models
{
    public static class PublicStaticClass
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