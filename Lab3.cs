using System;

public class String
{
    protected string value;

    public String(string value = "")
    {
        this.value = value;
    }

    public override string ToString()
    {
        return value;
    }
}

public class DecimalString : String
{
    public DecimalString(string value = "") : base(value)
    {
        if (value.Length > 0)
        {
            char firstChar = value[0];
            if (firstChar != '+' && firstChar != '-' && !Char.IsDigit(firstChar))
            {
                this.value = "";
            }
            else if (firstChar == '+' && value.Length == 1)
            {
                this.value = "";
            }
        }
    }

    public decimal ToDecimal()
    {
        decimal result = 0;
        if (decimal.TryParse(value, out result))
        {
            return result;
        }
        return 0;
    }

    public static DecimalString operator -(DecimalString a, DecimalString b)
    {
        decimal result = a.ToDecimal() - b.ToDecimal();
        return new DecimalString(result.ToString());
    }

    public static bool operator >(DecimalString a, DecimalString b)
    {
        return a.ToDecimal() > b.ToDecimal();
    }

    public static bool operator <(DecimalString a, DecimalString b)
    {
        return a.ToDecimal() < b.ToDecimal();
    }
}

class Program
{
    static void Main(string[] args)
    {
        DecimalString num1 = new DecimalString("+12423");
        DecimalString num2 = new DecimalString("-6456");
        Console.WriteLine($"num1: {num1}");
        Console.WriteLine($"num2: {num2}");
        Console.WriteLine($"num1 - num2 = {num1 - num2}");
        Console.WriteLine($"num1 > num2: {num1 > num2}");
        Console.WriteLine($"num1 < num2: {num1 < num2}");
        Console.ReadLine();
    }
   
}
