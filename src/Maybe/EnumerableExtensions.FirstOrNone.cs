// Monadic: .NET monads for functional style.
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2019

using System.Collections.Generic;
using System.Linq;

namespace Monadic;

public static partial class EnumerableExtensions
{
	/// <summary>
	/// Safely get the first value from a list.
	/// </summary>
	/// <typeparam name="T">IEnumerable value type.</typeparam>
	/// <param name="this">IEnumerable object</param>
	/// <returns>Value of the first element of <paramref name="this"/>, or <see cref="None"/>.</returns>
	public static Maybe<T> FirstOrNone<T>(this IEnumerable<T> @this) =>
		@this.FirstOrDefault() switch
		{
			T value =>
				value,

			_ =>
				M.None
		};
}
