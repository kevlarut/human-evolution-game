using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
    public static class LinqExtensionMethods
    {
        public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector) {
            var knownKeys = new HashSet<TKey>();
            return source.Where(x => knownKeys.Add(keySelector(x)));
        }
    }
}
