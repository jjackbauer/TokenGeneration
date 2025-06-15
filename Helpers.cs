using System.Text;

public static class Helpers
{
    public static string ToBase62(ulong value, int length)
    {
        StringBuilder sb = new StringBuilder();

        do
        {
            sb.Insert(0, ITokenGenerator.Characters[(int)(value % 62)]);
            value /= 62;
        } while (value > 0);
        

        return sb.ToString().PadLeft(length, '0');
    }
    public static ulong MaxValueForBase62Length(int length)
    {
        System.Numerics.BigInteger result = 1;

        for (int i = 0; i < length; i++)
            result *= 62;

        result -= 1;

        return result > ulong.MaxValue ? ulong.MaxValue : (ulong)result;
    }
}