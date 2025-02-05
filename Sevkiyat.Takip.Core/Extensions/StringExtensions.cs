namespace Sevkiyat.Takip.Core.Extensions;

public static class StringExtensions
{
    public static string ToCapitalize(this string input, char[]? delimiters = null)
    {
        if (string.IsNullOrWhiteSpace(input))
            return input;

        delimiters ??= new char[] { ' ' };

        var words = input.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i < words.Length; i++)
        {
            if (words[i].Length > 0)
            {
                words[i] = char.ToUpper(words[i][0]) + words[i].Substring(1).ToLower();
            }
        }

        return string.Join(" ", words);
    }
}
