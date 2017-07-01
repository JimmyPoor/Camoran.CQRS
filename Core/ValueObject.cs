using System;
using System.Collections.Generic;
using System.Text;

namespace Camoran.CQRS.Core
{
    public class ValueObject
    {
        IEnumerable<object> _values;

        public IEnumerable<object> Values => _values;

        public ValueObject() { }

        public ValueObject(IEnumerable<object> values)
        {
            _values = values;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            var vo = obj as ValueObject;
            var er_obj = vo.Values.GetEnumerator();
            var er = _values.GetEnumerator();
            while (er.MoveNext() && er_obj.MoveNext())
            {
                if (!er.Current.Equals(er_obj.Current)) return false;
            }

            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        } 

    }
}
