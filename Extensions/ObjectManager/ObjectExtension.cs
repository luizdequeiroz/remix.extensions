using System;
using System.Linq;

namespace System.Objects
{
    public static class ObjectExtension
    {
        public static void SetProperties<T, F>(this T to, F from, params string[] exceptions)
        {
            foreach (var propTo in to.GetType().GetProperties())
            {
                foreach (var propFrom in from.GetType().GetProperties())
                {
                    if (propFrom.Name == propTo.Name)
                    {
                        if (propTo.CustomAttributes.Where(ca => ca.AttributeType.Name == "KeyAttribute" || ca.AttributeType.Name == "DatabaseGeneratedAttribute").Count() == 0)
                        {
                            if (!exceptions.Contains(propFrom.Name))
                            {
                                var fromValue = propFrom.GetValue(from);

                                if (fromValue != null)
                                {
                                    propTo.SetValue(to, fromValue);
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
