// Monadic: .NET monads for functional style.
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2019

using System;
using System.Threading.Tasks;

namespace Monadic.Linq;

public static partial class ResultExtensions
{
	/// <summary>
	/// Enables LINQ Select() on <see cref="Result{T}"/> objects.
	/// </summary>
	/// <remarks>
	/// <para>
	/// For example:
	/// </para>
	/// <code>
	/// from x in Result
	/// select x
	/// </code>
	/// <para>
	/// Returns value of x if <see cref="Result{T}"/> object is <see cref="Ok{T}"/>,
	/// and <see cref="Err{T}"/> if not.
	/// </para>
	/// </remarks>
	/// <typeparam name="T">Result type</typeparam>
	/// <typeparam name="TReturn">Return type</typeparam>
	/// <param name="this">Result</param>
	/// <param name="f">Return map function</param>
	public static Result<TReturn> Select<T, TReturn>(this Result<T> @this, Func<T, TReturn> f) =>
		@this.Map(f);

	/// <inheritdoc cref="Select{T, TReturn}(Result{T}, Func{T, TReturn})"/>
	public static Task<Result<TReturn>> Select<T, TReturn>(this Result<T> @this, Func<T, Task<TReturn>> f) =>
		@this.MapAsync(f);

	/// <inheritdoc cref="Select{T, TReturn}(Result{T}, Func{T, TReturn})"/>
	public static Task<Result<TReturn>> Select<T, TReturn>(this Task<Result<T>> @this, Func<T, TReturn> f) =>
		@this.MapAsync(f);

	/// <inheritdoc cref="Select{T, TReturn}(Result{T}, Func{T, TReturn})"/>
	public static Task<Result<TReturn>> Select<T, TReturn>(this Task<Result<T>> @this, Func<T, Task<TReturn>> f) =>
		@this.MapAsync(f);
}
