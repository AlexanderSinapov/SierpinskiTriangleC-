namespace SierpinskiTriangle
{
    internal class Program
    {
        static ConsoleColor[] colors = (ConsoleColor[])ConsoleColor.GetValues(typeof(ConsoleColor));
        static void Main(string[] args)
        {
            int h = 32;
            char[,] triangle = new char[h, 2 * h - 1];

            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j < 2 * h - 1; j++)
                {
                    triangle[i, j] = ' ';
                }
            }

            GenerateTriangle(triangle, h, 0, h - 1);

            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j < 2 * h - 1; j++)
                {
                    Console.ForegroundColor = GetColor(i, j);
                    Console.Write(triangle[i, j]);
                    Console.ResetColor();
                }
                Console.WriteLine();
            }
        }

        static void GenerateTriangle(char[,] triangle, int s, int topX, int topY)
        {
            if (s == 1)
            {
                if (topX >= 0 && topX < triangle.GetLength(0) && topY >= 0 && topY < triangle.GetLength(1))
                {
                    triangle[topX, topY] = '*';
                }
            }
            else
            {
                int newS = s / 2;

                GenerateTriangle(triangle, newS, topX, topY);
                GenerateTriangle(triangle, newS, topX + newS, topY - newS);
                GenerateTriangle(triangle, newS, topX + newS, topY + newS);
            }
        }

        static ConsoleColor GetColor(int i, int j)
        {
            int colorIndex = (i + j) % colors.Length;
            return colors[colorIndex];
        }
    }
}
