// Monadic: .NET monads for functional style.
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2019

using System;

namespace Monadic.Exceptions;

/// <summary>
/// Thrown when a switch function encounters an <see cref="Result{T}"/> type that is
/// neither <see cref="Ok{T}"/> nor <see cref="Err"/>.
/// </summary>
public sealed class InvalidResultTypeException : InvalidTypeException
{
	/// <summary>Create exception.</summary>
	/// <param name="type">The invalid type that has been encountered.</param>
	internal InvalidResultTypeException(Type type) : base(type, typeof(Result<>), typeof(Err), typeof(Ok<>)) { }
}
