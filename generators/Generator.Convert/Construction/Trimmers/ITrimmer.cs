using JetBrains.Annotations;

namespace Generator.Convert.Construction.Trimmers
{
    /// <summary>
    /// Represents a class that can trim the identifier for some type in some fashion.
    /// </summary>
    /// <typeparam name="TTrimmable">The trimmable type.</typeparam>
    public interface ITrimmer<TTrimmable>
    {
        /// <summary>
        /// Determines if the name trimmer is relevant for the given type.
        /// </summary>
        /// <param name="trimmable">The type to check.</param>
        /// <returns>true if the name trimmer is relevant; otherwise, false.</returns>
        bool IsRelevant([NotNull] TTrimmable trimmable);

        /// <summary>
        /// Trims the given type.
        /// </summary>
        /// <param name="trimmable">The type to trim.</param>
        /// <returns>The trimmed type.</returns>
        [NotNull, Pure]
        void Trim([NotNull] TTrimmable trimmable);
    }
}
