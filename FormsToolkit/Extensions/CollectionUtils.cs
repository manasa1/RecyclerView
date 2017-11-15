using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Reflection;

namespace FormsToolkit.Extensions
{
    public static class CollectionUtils
    {

        public static int Count(this IEnumerable enumerable)
        {
            var enumerator = enumerable.GetEnumerator();

            int index = 0;
            while (enumerator.MoveNext())
                index++;

            return index;
        }

        public static T ElementAt<T>(this IEnumerable enumerable, int index)
        {
            if (enumerable == null)
                return default(T);

            if (enumerable is IList)
                return (T) ((IList)enumerable)[index];

            var enumerator = enumerable.GetEnumerator();

            var i = 0;
            while (enumerator.MoveNext())
            {
                if (i == index)
                    return (T) enumerator.Current;

                i++;
            }

            return default(T);
        }
        
    }
}
