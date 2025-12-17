using System;

public static class LargestSeriesProduct
{
    public static long GetLargestProduct(string digits, int span)
    {
        if (digits == null) throw new ArgumentNullException(nameof(digits));
        if (span < 0) throw new ArgumentException("Span must not be negative.", nameof(span));
        if (span > digits.Length) throw new ArgumentException("Span must be smaller than string length.", nameof(span));

        // Перевірка: тільки цифри
        foreach (char c in digits)
        {
            if (c < '0' || c > '9')
                throw new ArgumentException("Digits input must only contain digits.", nameof(digits));
        }

        if (span == 0) return 1;

        long best = 0;

        for (int i = 0; i <= digits.Length - span; i++)
        {
            long product = 1;

            for (int j = 0; j < span; j++)
            {
                int d = digits[i + j] - '0';
                product *= d;
            }

            if (product > best) best = product;
        }

        return best;
    }
}
