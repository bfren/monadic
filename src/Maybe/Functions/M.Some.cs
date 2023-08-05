// Monadic: .NET monads for functional style.
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2019

using System.Diagnostics.CodeAnalysis;

namespace Monadic;

public static partial class M
{
	public static Maybe<T> Some<T>([DisallowNull] T value) =>
		new Some<T>(value);
}
