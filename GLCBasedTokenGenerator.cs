public class GLCBasedTokenGenerator : ITokenGenerator
{
    // Constants for a 64-bit LCG (Linear Congruential Generator)
    private const ulong A = 6364136223846793005UL;
    private ulong C = 1UL;

    private ulong _state = 41UL; // Initial seed

    public string GenerateToken(int length)
    {
        if (length <= 0)
        {
            throw new ArgumentException("Length must be a positive integer.", nameof(length));
        }

        return Helpers.ToBase62(
            GLCNext(
                Helpers.
                MaxValueForBase62Length(
                    length
                    ))
                , length);
    }

    private ulong GLCNext(ulong maxExclusive)
    {
        if (maxExclusive == 0)
            throw new ArgumentException("maxExclusive must be > 0", nameof(maxExclusive));

        _state = A * _state + C;
        C++;
        return _state % maxExclusive;
    }
}


