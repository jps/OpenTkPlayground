using System;
using OpenTK.Graphics;

namespace OpenTkPlayground.Helpers
{
    public static class RandomColorGenerator
    {
        private static Random _random;

        public static Color4 NextColor()
        {
            if (_random == null)
            {
                _random = new Random();
            }

            return new Color4(
                (float) _random.NextDouble(),
                (float) _random.NextDouble(),
                (float) _random.NextDouble(),
                (float) _random.NextDouble());
        }
    }
}
