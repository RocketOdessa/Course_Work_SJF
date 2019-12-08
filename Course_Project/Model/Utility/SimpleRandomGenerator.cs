using System;

namespace Model.Utility
{
    public static class SimpleRandomGenerator
    {
        private static Random randomGenerator;

        static SimpleRandomGenerator()
        {
            randomGenerator = new Random();
        }

        public static int GetRendomTime()
        {
            return randomGenerator.Next(1, 5);
        }
    }
}
