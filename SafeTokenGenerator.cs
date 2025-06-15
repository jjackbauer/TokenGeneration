using System.Security.Cryptography;
using System.Text;
public class SafeTokenGenerator : ITokenGenerator
{
    public string GenerateToken(int length)
    {
        return Helpers.
                ToBase62
                (
                    GenerateRandomULongBounded
                    (
                        Helpers.MaxValueForBase62Length(length) + 1 
                    ),
                    length
                );
    }
    static ulong GenerateRandomULongBounded(ulong maxExclusive)
    {
        if (maxExclusive == 0)
            throw new ArgumentException("maxExclusive must be > 0");

        byte[] buffer = new byte[8];
        ulong result;

        ulong limit = ulong.MaxValue - (ulong.MaxValue % maxExclusive);

        do
        {
            RandomNumberGenerator.Fill(buffer);
            result = BitConverter.ToUInt64(buffer, 0);
        }
        while (result >= limit);

        return result % maxExclusive;
    }
}