public static class SpiralMatrix
{
    public static int[,] GetMatrix(int size)
    {
        int[,] matrix = new int[size, size];

        int value = 1;
        int top = 0;
        int bottom = size - 1;
        int left = 0;
        int right = size - 1;

        while (value <= size * size)
        {
            // → вправо
            for (int i = left; i <= right; i++)
                matrix[top, i] = value++;
            top++;

            // ↓ вниз
            for (int i = top; i <= bottom; i++)
                matrix[i, right] = value++;
            right--;

            // ← вліво
            for (int i = right; i >= left; i--)
                matrix[bottom, i] = value++;
            bottom--;

            // ↑ вгору
            for (int i = bottom; i >= top; i--)
                matrix[i, left] = value++;
            left++;
        }

        return matrix;
    }
}
