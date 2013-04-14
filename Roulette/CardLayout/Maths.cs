using System;

namespace Roulette
{
    public static class Maths
    {
        public static float DegreesToRadians(float degrees)
        {
            return (float) ((degrees)/180.0*Math.PI);
        }
    }
}