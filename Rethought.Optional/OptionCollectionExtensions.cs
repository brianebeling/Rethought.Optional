using System;
using System.Collections.Generic;
using System.Linq;

namespace Rethought.Optional
{
    public static class OptionCollectionExtensions
    {
        public static IEnumerable<T> Flatten<T>(this IEnumerable<Option<T>> source)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            foreach (var option in source)
            {
                if (option.HasValue)
                {
                    yield return option.Value;
                }
            }
        }

        public static Option<TSource> FirstOrNone<TSource>(this IEnumerable<TSource> source)
        {
            return source.FirstOrDefault();
        }

        public static Option<TSource> FirstOrNone<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, bool> predicate)
        {
            return source.FirstOrDefault(predicate);
        }

        public static Option<TSource> LastOrNone<TSource>(this IEnumerable<TSource> source)
        {
            return source.LastOrDefault();
        }

        public static Option<TSource> LastOrNone<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, bool> predicate)
        {
            return source.LastOrDefault(predicate);
        }

        public static Option<TSource> SingleOrNone<TSource>(this IEnumerable<TSource> source)
        {
            return source.SingleOrDefault();
        }

        public static Option<TSource> SingleOrNone<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, bool> predicate)
        {
            return source.SingleOrDefault(predicate);
        }

        public static Option<TSource> ElementAtOrNone<TSource>(this IEnumerable<TSource> source, int index)
        {
            return source.ElementAtOrDefault(index);
        }
    }
}