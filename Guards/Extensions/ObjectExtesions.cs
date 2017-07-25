using System;

namespace Guards.Extensions
{
    public static class ObjectExtesions
    {
        public static void EnsureNotNull(this object o)
        {
           if(o==null || ReferenceEquals(o, null))
            {
                throw new NullReferenceException();
            }
        }

        public static void WhenNull(this object o, Action a)
        {
            if (o == null || ReferenceEquals(o, null))
            {
                if (a != null) a.Invoke();
            }
        }
    }
}
