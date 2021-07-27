namespace System.Objects
{
    public static class ComparerExtension
    {
        public static bool Equals<T>(this T x, T y)
        {
            var genericComparer = new GenericComparer<T>();
            return genericComparer.Equals(x, y);
        }
    }
}
