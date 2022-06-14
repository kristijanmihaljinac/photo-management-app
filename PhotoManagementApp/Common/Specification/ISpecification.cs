using System.Linq.Expressions;

namespace Common.Specification
{
    /// <summary>
    /// This is a minimal implementation only. Let me explain each of the declared method definitions.
    /// Criteria – This is where you can add in the expressions based on your entity.
    /// Includes – If you want to include foreign keyed table data, you could add it using this method.
    /// OrderBy and OrderByDescending are quite self-explanatory.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>> Criteria { get; }
        List<Expression<Func<T, object>>> Includes { get; }
        Expression<Func<T, object>> OrderBy { get; }
        Expression<Func<T, object>> OrderByDescending { get; }
        public int? Skip { get;  }
        public int? Take { get;  }
    }
}
