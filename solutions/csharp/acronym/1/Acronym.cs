using System.Text;

public static class Acronym
{
    public static string Abbreviate(string phrase)
    {
        StringBuilder result = new StringBuilder();
        bool newWord = true;

        foreach (char c in phrase)
        {
            if (char.IsLetter(c))
            {
                if (newWord)
                {
                    result.Append(char.ToUpper(c));
                    newWord = false;
                }
            }
            else if (c == ' ' || c == '-')
            {
                newWord = true;
            }
            // іншу пунктуацію (', !, .) просто ігноруємо
        }

        return result.ToString();
    }
}
