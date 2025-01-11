namespace Lab1_Exercise2
{
    public class Solution
    {
        public int Divide(int dividend, int divisor)
        {
            // Handle special cases
            if (dividend == int.MinValue && divisor == -1) return int.MaxValue;
            if (divisor == 1) return dividend;
            if (divisor == -1) return -dividend;

            // Convert to long to handle int.MinValue case
            long absDividend = Math.Abs((long)dividend);
            long absDivisor = Math.Abs((long)divisor);
            bool isNegative = (dividend < 0) ^ (divisor < 0);

            int result = 0;

            // Use bit manipulation for faster division
            while (absDividend >= absDivisor)
            {
                long temp = absDivisor;
                long multiple = 1;

                // Find largest multiple of divisor that's <= dividend
                while (absDividend >= (temp << 1) && (temp << 1) > 0)
                {
                    temp <<= 1;
                    multiple <<= 1;
                }

                absDividend -= temp;
                result += (int)multiple;
            }

            return isNegative ? -result : result;
        }
    }
}
