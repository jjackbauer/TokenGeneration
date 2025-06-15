using System.Text;

public class SingleGenTokenGenerator : ITokenGenerator
{

    private static readonly Random Random = new Random();

    public string GenerateToken(int length)
    {
        return Helpers.ToBase62(
                GenerateRandomULong(
                    Helpers.
                    MaxValueForBase62Length(length)+1
                ),
                length
            );
    }

    static ulong GenerateRandomULong(ulong max)
    {
        if (max == 0) return 0;

        byte[] buffer = new byte[8];
        Random.NextBytes(buffer);
        ulong result = BitConverter.ToUInt64(buffer, 0);
        
        return result % (max + 1);
    }
}