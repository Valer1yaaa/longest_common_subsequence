class Program
{
    static void Main()
    {
        Console.Write("Enter the first line: ");
        string line1 = Console.ReadLine();

        Console.Write("Enter the second line: ");
        string line2 = Console.ReadLine();

        string result = FindLCS(line1, line2);
        Console.WriteLine("The maximum common subsequence: " + result);
    }
    static string FindLCS(string line1, string line2)
    {
        int m = line1.Length;
        int n = line2.Length;

        int[,] dp = new int[m + 1, n + 1];

        for (int i = 1; i <= m; i++)
        {
            for (int j = 1; j <= n; j++)
            {
                if (line1[i - 1] == line2[j - 1])
                {
                    dp[i, j] = dp[i - 1, j - 1] + 1;
                }
                else
                {
                    dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
                }
            }
        }

        string lcs = "";
        int x = m;
        int y = n;
        while (x > 0 && y > 0)
        {
            if (line1[x - 1] == line2[y - 1])
            {
                lcs = line1[x - 1] + lcs;
                x--;
                y--;
            }
            else if (dp[x - 1, y] > dp[x, y - 1])
            {
                x--;
            }
            else
            {
                y--;
            }
        }
        return lcs;
    }
}