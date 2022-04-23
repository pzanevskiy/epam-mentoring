using System;
using System.Collections.Generic;
using System.Linq;

namespace CircularPrimes.Lib
{
    public class CircularPrimeService
    {
        public int GetCircularPrimesAmount(int count)
        {
            return Enumerable.Range(0, count).Count(IsCircularPrime);
        }

        public IEnumerable<int> GetCircularPrimes(int count)
        {
            return Enumerable.Range(0, count).Where(IsCircularPrime);
        }

        public bool IsCircularPrime(int number)
        {
            if (number < 0) throw new ArgumentOutOfRangeException();

            return Enumerable.Range(0, GetIntLength(number))
                .All(shift => IsPrime(RotateShift(number, shift)));
        }

        private static bool IsPrime(int number)
        {
            if (number <= 1) return false;
            if (number == 2) return true;

            if (number % 2 == 0) return false;

            var sqrt = (int)Math.Ceiling(Math.Sqrt(number));

            for (int i = 3; i <= sqrt; i += 2)
            {
                if (number % i == 0) return false;
            }

            return true;
        }

        private static int RotateShift(int value, int shift)
        {
            int len = (int)Math.Log10(value) + 1;
            shift %= len;
            if (shift < 0) shift += len;
            int pow = (int)Math.Pow(10, shift);
            return (value % pow) * (int)Math.Pow(10, len - shift) + value / pow;
        }

        private static int GetIntLength(int number) => number == 0 ? 1 : (int)Math.Log10(number) + 1;
    }
}
