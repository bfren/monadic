// Monadic: .NET monads for functional style.
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2019

using Monadic.Exceptions;

namespace Monadic;

public static partial class R
{
	/// <summary>
	/// Return a 'true' <see cref="Ok{T}"/> result.
	/// </summary>
	/// <returns><see cref="Ok{T}"/> result containing the value <c>true</c>.</returns>
	public static Result<bool> Ok() =>
		Wrap(true);

	/// <summary>
	/// One of the most important functions in the library: takes a value and returns
	/// either <see cref="Ok{T}"/> or <see cref="Monadic.Err"/>.
	/// </summary>
	/// <remarks>
	/// <para>
	/// If <paramref name="value"/> is not null, you will get an <see cref="Ok{T}"/> object where
	/// <see cref="Ok{T}.Value"/> is <paramref name="value"/>.
	/// </para>
	/// <para>
	/// If <paramref name="value"/> is null and <typeparamref name="T"/> is a nullable value type,
	/// you will get a <see cref="Ok{T}"/> object where <see cref="Ok{T}.Value"/> is null.
	/// </para>
	/// <para>
	/// If <paramref name="value"/> is null and <typeparamref name="T"/> is a reference type (with or
	/// without the ? suffix), you will get an <see cref="Monadic.Err"/> object.
	/// </para>
	/// </remarks>
	/// <typeparam name="T">Result value type.</typeparam>
	/// <param name="value">Value to wrap.</param>
	/// <returns>
	/// <see cref="Ok{T}"/> if <paramref name="value"/> is not null
	/// or <typeparamref name="T"/> is a nullable value type -
	/// otherwise <see cref="Monadic.Err"/>.
	/// </returns>
	public static Result<T> Wrap<T>(T value) =>
		value switch
		{
			T x =>
				new Ok<T>(x),

			_ when F.IsNullableValueType(value) =>
				new Ok<T>(value!),

			_ =>
				Err<OkValueCannotBeNullException>()
		};
}
