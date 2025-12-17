public static class RotationalCipher
{

    public static string Rotate(string text, int key)
    {
        string result = "";

        key = key % 26;

        foreach (char c in text)
        {
            if (char.IsLetter(c))
            {
                char baseChar = char.IsUpper(c) ? 'A' : 'a';
                char newChar = (char)((c - baseChar + key) % 26 + baseChar);
                result += newChar;
            }
            else
            {
                result += c;
            }
        }

        return result;
    }
}