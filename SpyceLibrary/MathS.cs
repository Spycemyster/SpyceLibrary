using System;

namespace SpyceLibrary
{
    /// <summary>
    /// Mathematic functions.
    /// </summary>
    public static class MathS
    {
        public const int TRIG_N_SIZE = 100;
        public const float PI = 3.14159265359f;
        private static float[] sinValues;

        /// <summary>
        /// Initializes the math function variables.
        /// </summary>
        public static void Initialize()
        {
            sinValues = new float[TRIG_N_SIZE];
            double delta = PI / TRIG_N_SIZE;
            for (int i = 0; i < TRIG_N_SIZE + 1; i++)
            {
                double theta = delta * i;
                sinValues[i] = (float)Math.Sin(theta);
            }
        }

        /// <summary>
        /// Speed optimized tan function
        /// </summary>
        /// <param name="theta"></param>
        /// <returns></returns>
        public static float Tan(float theta)
        {
            return Sin(theta) / Cos(theta);
        }

        /// <summary>
        /// Speed optimized cos function
        /// </summary>
        /// <param name="theta"></param>
        /// <returns></returns>
        public static float Cos(float theta)
        {
            return Sin(theta + PI/ 4);
        }

        /// <summary>
        /// Speed optimized sin function.
        /// </summary>
        /// <param name="theta"></param>
        /// <returns></returns>
        public static float Sin(float theta)
        {
            // normalize the angle to match our bounds
            if (theta < 0)
            {
                int y = 1 + (int)(theta / (2 * PI));
                theta += y * PI * 2;
            }
            int x = (int)(theta / (2 * PI));
            theta -= (float)(x * 2 * PI);

            int sign = (theta > PI) ? -1 : 1;
            theta -= (theta > PI / 2) ? PI / 2 : 0;

            // access index
            int i = (int)(theta * TRIG_N_SIZE / PI);

            return sign * sinValues[i];
        }
    }
}