namespace CalcStats.Lib
{
    public class CalcStatsService
    {
        public int GetMinValue(int[] sequence)
        {
            int min = sequence[0];

            for (int i = 1; i < sequence.Length; i++)
            {
                if (min > sequence[i])
                {
                    min = sequence[i];
                }
            }

            return min;
        }

        public int GetMaxValue(int[] sequence)
        {
            int max = sequence[0];

            for (int i = 1; i < sequence.Length; i++)
            {
                if (max < sequence[i])
                {
                    max = sequence[i];
                }
            }

            return max;
        }

        public int GetSequenceCount(int[] sequence)
        {
            return sequence.Length;
        }

        public double GetAverageValue(int[] sequence)
        {
            int sequenceSum = 0;

            foreach (var value in sequence)
            {
                sequenceSum += value;
            }

            var average = (double)sequenceSum / sequence.Length;

            return average;
        }
    }
}
