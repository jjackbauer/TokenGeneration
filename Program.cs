var length = 6; 
var sw = System.Diagnostics.Stopwatch.StartNew();
List<ITokenGenerator> tokenGenerators = new List<ITokenGenerator>
{
    new SafeTokenGenerator(),
    new SingleGenTokenGenerator(),
    new TokenGenerator(),
    new HashBasedTokenGenerator(),
    new GLCBasedTokenGenerator(),
};


while (true)
{

    foreach (var generator in tokenGenerators)
    {
        sw.Restart();
        string token = generator.GenerateToken(length);
        Console.WriteLine($"Generated Token: {token} using {generator.GetType().Name} - {sw.ElapsedMilliseconds} ms");
    }
    
    Console.WriteLine("Press any key to generate again or 'q' to quit...");
    var key = Console.ReadKey(true).Key;
    if (key == ConsoleKey.Q)
        break;
    
    Console.WriteLine();

}