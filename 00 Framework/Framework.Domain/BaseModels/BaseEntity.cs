using Framework.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Framework.Domain.BaseModels
{
    public abstract class BaseEntity<TId> where TId : IEquatable<TId>
    {
        public TId Id { get; protected set; }

        private readonly List<IEvent> _events;

        protected BaseEntity()
            => _events = new List<IEvent>();

        protected void AddEvent(IEvent @event)
            => _events.Add(@event);

        public IEnumerable<IEvent> GetEvents()
            => _events.AsEnumerable();

        public void ClearEvents()
            => _events.Clear();

        public override bool Equals(object obj)
        {
            var other = obj as BaseEntity<TId>;

            if (ReferenceEquals(other, null))
                return false;

            if (ReferenceEquals(this, other))
                return true;

            if (GetType() != other.GetType())
                return false;

            if (Id.Equals(default) || other.Id.Equals(default))
                return false;

            return Id.Equals(other.Id);
        }

        public static bool operator ==(BaseEntity<TId> a, BaseEntity<TId> b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(BaseEntity<TId> a, BaseEntity<TId> b) => !(a == b);

        public override int GetHashCode() => (GetType().ToString() + Id).GetHashCode();
    }
}