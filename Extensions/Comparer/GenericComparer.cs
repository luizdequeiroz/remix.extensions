using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace System.Objects
{
    public class GenericComparer<T> : IEqualityComparer<T>
    {
        public bool Equals([AllowNull] T x, [AllowNull] T y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (x is null || y is null)
                return false;

            var propertiesX = x.GetType().GetProperties();
            var propertiesY = y.GetType().GetProperties();
            var propertiesCount = propertiesX.Count();

            var equalsCount = 0;

            foreach (var propertyX in propertiesX)
                foreach (var propertyY in propertiesY)
                    if (propertyX.Name == propertyY.Name)
                        if (propertyX.GetValue(x)?.ToString() == propertyY.GetValue(y)?.ToString())
                            equalsCount++;

            return propertiesCount == equalsCount;
        }

        public int GetHashCode([DisallowNull] T obj)
        {
            if (obj is null) return 0;

            int hashCodeObject = 0;

            foreach (var property in obj.GetType().GetProperties())
            {
                var value = property.GetValue(obj);
                var hashCode = (value != null ? value.GetHashCode() : 0);

                if (hashCodeObject == 0) hashCodeObject = hashCode;
                else hashCodeObject ^= hashCode;
            }

            return hashCodeObject;
        }
    }
}
