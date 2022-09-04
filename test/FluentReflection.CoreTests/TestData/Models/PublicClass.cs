namespace FluentReflection.TestData.TestData.Models
{
    public class PublicClass
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