// Wrap: .NET monads for functional style.
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2019

namespace Wrap;

public readonly struct Err
{
	public readonly required ErrValue Value { get; init; }
}
