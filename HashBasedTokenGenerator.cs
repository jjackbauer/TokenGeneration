using System.Numerics;
using System.Security.Cryptography;
using System.Text;

public class HashBasedTokenGenerator : ITokenGenerator
{
    private readonly string salt = "default_salt"; //this should be a secret value in a real application
    public string GenerateToken(int length)
    {
        if (length <= 0)
            throw new ArgumentOutOfRangeException(nameof(length), "Token length must be positive.");

        string seed = $"{salt}-{Guid.NewGuid()}:{DateTime.UtcNow.Ticks}:{Environment.TickCount64}:{AppDomain.CurrentDomain.Id}:{Environment.WorkingSet}";
        byte[] seedBytes = Encoding.UTF8.GetBytes(seed);

        using var sha = SHA256.Create();
        byte[] hash = sha.ComputeHash(seedBytes);

        string base62 = ToBase62(hash);

        if (base62.Length >= length)
            return base62[..length];
        else
            return ExpandToLength(base62, length);
    }

    private static string ToBase62(byte[] input)
    {
        const string base62Chars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

        BigInteger value = new BigInteger(input.Append((byte)0).ToArray());

        var sb = new StringBuilder();
        while (value > 0)
        {
            value = BigInteger.DivRem(value, 62, out var remainder);
            sb.Insert(0, base62Chars[(int)remainder]);
        }

        return sb.ToString();
    }

    private static string ExpandToLength(string base62, int desiredLength)
    {
        var sb = new StringBuilder(base62);
        while (sb.Length < desiredLength)
        {
            using var sha = SHA256.Create();
            var nextInput = Encoding.UTF8.GetBytes(sb.ToString());
            byte[] nextHash = sha.ComputeHash(nextInput);
            sb.Append(ToBase62(nextHash));
        }
        return sb.ToString()[..desiredLength];
    }
}