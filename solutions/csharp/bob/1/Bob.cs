using System;

public static class Bob
{
    public static string Response(string statement)
    {
        if (string.IsNullOrWhiteSpace(statement))
            return "Fine. Be that way!";

        bool isQuestion = statement.Trim().EndsWith("?");
        bool hasLetters = false;
        bool isYelling = true;

        foreach (char c in statement)
        {
            if (char.IsLetter(c))
            {
                hasLetters = true;
                if (!char.IsUpper(c))
                {
                    isYelling = false;
                    break;
                }
            }
        }

        isYelling = hasLetters && isYelling;

        if (isYelling && isQuestion)
            return "Calm down, I know what I'm doing!";

        if (isYelling)
            return "Whoa, chill out!";

        if (isQuestion)
            return "Sure.";

        return "Whatever.";
    }
}
