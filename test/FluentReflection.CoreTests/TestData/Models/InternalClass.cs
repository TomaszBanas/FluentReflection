namespace FluentReflection.TestData.TestData.Models
{
    internal class InternalClass
    {
        private int Value { get; set; }

        private void SetValue(int v)
        {
            Value = v;
        }

        private int GetValue()
        {
            return Value;
        }

        private static int Val2 { get; set; }

    }

}