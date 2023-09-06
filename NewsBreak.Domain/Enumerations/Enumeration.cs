using NewsBreak.Domain.Exceptions;
using System.Reflection;

namespace NewsBreak.Domain.Enumerations
{

    public abstract class Enumeration : IComparable
    {

        #region - - - - - - Constructors - - - - - -

        protected Enumeration() { }

        protected Enumeration(string name, long value)
        {
            this.Name = name;
            this.Value = value;
        }

        #endregion Constructors

        #region - - - - - - Properties - - - - - -

        public string Name { get; }

        public long Value { get; }

        #endregion Properties

        #region - - - - - - Methods - - - - - -

        public int CompareTo(object other)
            => this.Value.CompareTo(((Enumeration)other).Value);

        public override bool Equals(object obj)
        {
            var otherValue = obj as Enumeration;

            if (otherValue == null)
                return false;

            var typeMatches = this.GetType().Equals(obj.GetType());
            var valueMatches = this.Value.Equals(otherValue.Value);

            return typeMatches && valueMatches;
        }

        public static T FromName<T>(string name) where T : Enumeration
        {
            if (name == null)
                return null;

            return GetAll<T>()
                    .SingleOrDefault(vt => vt.Name == name)
                        ?? throw new InvalidEnumException(name);
        }

        public static T FromValue<T>(long value) where T : Enumeration
            => GetAll<T>()
                    .SingleOrDefault(vt => vt.Value == value)
                        ?? throw new InvalidEnumException(value.ToString());

        public static IEnumerable<T> GetAll<T>() where T : Enumeration
        {
            var fields = typeof(T).GetFields(BindingFlags.Public |
                                             BindingFlags.Static |
                                             BindingFlags.DeclaredOnly);

            return fields.Select(f => f.GetValue(null)).Cast<T>();
        }

        public override int GetHashCode()
            => this.Value.GetHashCode();

        public static implicit operator long(Enumeration enumeration)
            => enumeration.Value;

        public override string ToString()
            => this.Name;

        #endregion Methods

    }

}
