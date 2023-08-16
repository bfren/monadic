// Monadic: .NET monads for functional style.
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2019

using System;
using System.Threading.Tasks;

namespace Monadic;

public static partial class MaybeExtensions
{
	/// <summary>
	/// Unwrap the value contained in <paramref name="this"/>.
	/// </summary>
	/// <typeparam name="T">Maybe value type.</typeparam>
	/// <param name="this">Maybe object.</param>
	/// <param name="ifNone">Function to generate a value if <paramref name="this"/> is <see cref="None"/>.</param>
	/// <returns>The value of <paramref name="this"/> or generated by <paramref name="ifNone"/>.</returns>
	public static T Unwrap<T>(this Maybe<T> @this, Func<T> ifNone) =>
		M.Switch(@this,
			none: ifNone,
			some: x => x
		);

	/// <inheritdoc cref="Unwrap{T}(Maybe{T}, Func{T})"/>
	public static Task<T> UnwrapAsync<T>(this Maybe<T> @this, Func<Task<T>> ifNone) =>
		M.SwitchAsync(@this,
			none: ifNone,
			some: x => x
		);

	/// <inheritdoc cref="Unwrap{T}(Maybe{T}, Func{T})"/>
	public static Task<T> UnwrapAsync<T>(this Task<Maybe<T>> @this, Func<T> ifNone) =>
		M.SwitchAsync(@this,
			none: ifNone,
			some: x => Task.FromResult(x)
		);

	/// <inheritdoc cref="Unwrap{T}(Maybe{T}, Func{T})"/>
	public static Task<T> UnwrapAsync<T>(this Task<Maybe<T>> @this, Func<Task<T>> ifNone) =>
		M.SwitchAsync(@this,
			none: ifNone,
			some: x => Task.FromResult(x)
		);
}
