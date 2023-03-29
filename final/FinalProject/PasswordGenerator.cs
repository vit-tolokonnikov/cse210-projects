class PasswordGenerator
{
    private const string LowercaseChars = "abcdefghijklmnopqrstuvwxyz";
    private const string UppercaseChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    private const string DigitChars = "0123456789";
    private const string SpecialChars = "!@#$%^&*()_+";

    private readonly int _passwordLength;

    public PasswordGenerator(int passwordLength)
    {
        _passwordLength = passwordLength;
    }

    public string Generate()
    {
        var password = new char[_passwordLength];

        var chars = LowercaseChars.ToCharArray()
            .Concat(UppercaseChars.ToCharArray())
            .Concat(DigitChars.ToCharArray())
            .Concat(SpecialChars.ToCharArray())
            .OrderBy(x => Guid.NewGuid())
            .ToArray();

        password[0] = LowercaseChars[new Random().Next(LowercaseChars.Length)];
        password[1] = UppercaseChars[new Random().Next(UppercaseChars.Length)];
        password[2] = DigitChars[new Random().Next(DigitChars.Length)];
        password[3] = SpecialChars[new Random().Next(SpecialChars.Length)];

        for (int i = 4; i < _passwordLength; i++)
        {
            password[i] = chars[new Random().Next(chars.Length)];
        }

        password = password.OrderBy(x => Guid.NewGuid()).ToArray();

        return new string(password);
    }
}