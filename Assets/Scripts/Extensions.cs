using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    static class Extensions
    {
        private static readonly System.Random _rng = new System.Random();

        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = _rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        public static Color GetColor(this Region region)
        {
            return region switch
            {
                Region.Blue => new Color(0, 0, 1),
                Region.Yellow => Color.yellow,
                Region.Black => Color.black,
                Region.Red => Color.red,
                _ => Color.white,
            };
        }
    }
}
