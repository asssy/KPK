using System;

class CSharpRefactoring
{
    const int MaxCount = 6;

    public class BoolToString
    {
        public void ReverseBoolToString(bool number)
        {
            string numberToString = number.ToString();
            Console.WriteLine(numberToString);
        }
    }

    static void Main()
    {
        BoolToString value = new BoolToString();
        value.ReverseBoolToString(true);
    }
}