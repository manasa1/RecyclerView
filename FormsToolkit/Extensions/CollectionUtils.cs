using System.Collections;

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

    }
}
