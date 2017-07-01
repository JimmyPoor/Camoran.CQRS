using System;
using System.Collections.Generic;
using System.Text;

namespace Camoran.CQRS.Core
{
    public class Entity<T>
    {

        public virtual T EntityId { get; protected set; }

        public virtual bool IsDefaultId(T def=default(T)) => EntityId.Equals(def);

        public override int GetHashCode() => EntityId.GetHashCode() ^ 31;
        
        /// <summary>
        /// Entity equals roles: 
        /// 1 obj instance is not null 
        /// 2 obj instance is Entity
        /// 3 obj instance's id should be same 
        /// 4 obj id should not be default value
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Entity<T>)) return false;
            if (ReferenceEquals(obj, this)) return true;

            var entity = obj as Entity<T>;
            if (entity.IsDefaultId() || this.IsDefaultId()) return false;
            if (entity.EntityId.Equals(EntityId)) return true;

            return false;
        }

        public static bool operator ==(Entity<T> left, Entity<T> right)
        {
            return object.Equals(left, right) && left.Equals(right);
        }

        public static bool operator !=(Entity<T> left, Entity<T> right)
        {
            return !(left == right);
        }

    }
}
