public class TokenGenerator : ITokenGenerator
{
    private static readonly Random Random = new Random();

    public string GenerateToken(int length)
    {
        if (length <= 0)
        {
            throw new ArgumentException("Length must be a positive integer.", nameof(length));
        }

        char[] token = new char[length];
        
        for (int i = 0; i < length; i++)
        {
            token[i] = ITokenGenerator.Characters[Random.Next(ITokenGenerator.Characters.Length)];
        }

        return new string(token);
    }
}