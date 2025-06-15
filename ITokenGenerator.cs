public interface ITokenGenerator
{
   /// <summary>
   /// Represents the characters used in token generation.
   /// This includes uppercase letters, lowercase letters, and digits. aka Base62
   /// </summary>
    public const string Characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

    /// <summary>
    /// Generates a random token of the specified length.
    /// </summary>
    /// <param name="length">The length of the token to generate.</param>
    /// <returns>A randomly generated token as a string.</returns>
    /// <exception cref="ArgumentException">Thrown when the length is not a positive integer.</exception>
    string GenerateToken(int length);
}