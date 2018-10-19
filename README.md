# Rethought.Optional

Optional is a lightweight option/maybe type for C#.

It is heavily inspired by and based on [nlkl/Optional](https://github.com/nlkl/Optional). Thank you for your great work.

## Motivation

Optional is a strongly typed alternative to null values that lets you:

* Avoid null-reference exceptions and potential bugs
* Explicitly express the intent of return and parameter types

## Features

* Self contained with no dependencies
* Easily installed through NuGet
* Supports **.NET Core** (.NET Standard 2.0)

## Installation

Optional is also available via [NuGet](TODO):

```
PM> Install-Package Rethought.Optional
```

## Core concepts

The core concept behind Optional is derived from functional programming constructs, typically referred to as a maybe type (`Option<T>`)

Many functional programming languages disallow null values, as null-references can introduce hard-to-find bugs. A maybe type is a type-safe alternative to null values.

In general, an optional value can be in one of two states. Either is contains a value, or it does not. Unlike null, an option type forces the user to check if a value is actually present, thereby mitigating many of the problems of null values. `Option<T>` is a struct in Optional, making it impossible to assign a null value to an option itself.

Further, an option type is a lot more explicit than a null value, which can make APIs based on optional values a lot easier to understand. Now, the type signature will indicate if a value can be missing!

## Usage

### Using the library

The most basic way to create optional values is to use an implicit cast.

```csharp
Option<int> none = default;
Option<int> some = 1;
```

A (simplified) scenario could look like this:

```csharp
Print("Hello World!");
Print();

void Print(Option<string> messageOption = default)
```

### Retrieving values

When retrieving values, Optional forces you to consider both cases (that is if a value is present or not).

Firstly, it is possible to check if a value is actually present:

```csharp
var hasValue = option.HasValue;
```

The most basic (and recommended) way to retrieve a value from an `Option<T>` is the following:

```csharp
public void Print(Option<string> messageOption = default)
{
    if (messageOption.TryGetValue(out var message))
    {
        Console.WriteLine(message);
    }
    else
    {
        Console.WriteLine("No message provided!");
    }
}
```

### Retrieving values without safety

In some cases you might be absolutely sure that a value is present. Alternatively, the lack of a value might be fatal to your program, in which case you just want to indicate such a failure.

In such scenarios, Optional allows you to drive without a seatbelt.

When imported, values can be retrieved unsafely as:

```csharp
var value = option.ValueOrFailure();
var anotherValue = option.ValueOrFailure("An error message");
```

In case of failure an `OptionValueMissingException` is thrown.

In a lot of interop scenarios, it might be necessary to convert an option into a potentially null value. Once the Unsafe namespace is imported, this can be done relatively concisely as:

```csharp
var value = option.ValueOrDefault(); // value will be default(T) if the option is empty.
```

As a rule of thumb, such conversions should be performed only just before the nullable value is needed (e.g. passed to an external library), to minimize and localize the potential for null reference exceptions and the like.

### Transforming and filtering values

A few extension methods are provided to safely manipulate optional values.

The `Or` function makes it possible to specify an alternative value. If the option is none, a some instance will be returned:

```csharp
Option<int> none = default;
var some = none.Or(10); // A some instance, with value 10
var some = none.Or(() => SlowOperation()); // Lazy variant
```

Similarly, the `Else` function enables you to specify an alternative option, which will replace the current one, in case no value is present. Notice, that both options might be none, in which case a none-option will be returned:

```csharp
Option<int> none = default;
var some = none.Else(10); // A some instance, with value 10
var some = none.Else(default); // A none instance
var some = none.Else(() => 0); // Lazy variant
```

### Equivalence and comparison

Two optional values are equal if the following is satisfied:

* The two options have the same type
* Both are none, both contain null values, or the contained values are equal

An option both overrides `object.Equals` and implements `IEquatable<T>`, allowing efficient use in both generic and untyped scenarios. The `==` and `!=` operators are also provided for convenience. In each case, the semantics are identical.

The generated hashcodes also reflect the semantics described above.

Further, options implement `IComparable<T>` and overload the corresponding comparison operators (`< > <= >=`). The implementation is consistent with the above described equality semantics, and comparison itself is based on the following rules:

* An empty option is considered less than a non-empty option
* For non-empty options comparison is delegated to the default comparer and applied on the contained value

### Working with collections

Optional provides a few convenience methods to ease interoperability with common .NET collections, and improve null safety a bit in the process.

LINQ provides a lot of useful methods when working with enumerables, but methods such as `FirstOrDefault`, `LastOrDefault`, `SingleOrDefault`, and `ElementAtOrDefault`, all return null (more precisely `default(T)`) to indicate that no value was found (e.g. if the enumerable was empty). Optional provides a safer alternative to all these methods, returning an option to indicate success/failure instead of nulls. As an added benefit, these methods work unambiguously for non-nullable/structs types as well, unlike their LINQ counterparts. 

```csharp
var option = values.FirstOrNone();
var option = values.FirstOrNone(v => v != 0);
var option = values.LastOrNone();
var option = values.LastOrNone(v => v != 0);
var option = values.SingleOrNone();
var option = values.SingleOrNone(v => v != 0);
var option = values.ElementAtOrNone(10);
```

(Note that unlike `SingleOrDefault`, `SingleOrNone` never throws an exception but returns None in all "invalid" cases. This slight deviation in semantics was considered a safer alternative to the existing behavior, and is easy to work around in practice, if the finer granularity is needed.)

Optional provides a safe way to retrieve values from a dictionary:

```csharp
var option = dictionary.GetValueOrNone("key");
```

`GetValueOrNone` behaves similarly to `TryGetValue` on an `IDictionary<TKey, TValue>` or `IReadOnlyDictionary<TKey, TValue>`, but actually supports any `IEnumerable<KeyValuePair<TKey, TValue>>` (falling back to iteration, when a direct lookup is not possible).

Another common scenario, is to perform various transformations on an enumerable and ending up with a sequence of options (e.g. `IEnumerable<Option<T>>`). In many cases, only the non-empty options are relevant, and as such Optional provides a convenient method to flatten a sequence of options into a sequence containing all the inner values (whereas empty options are simply thrown away):

```csharp
var options = new List<Option<int>> { 1, 2, default };
var values = option.Values(); // IEnumerable<int> { 1, 2 }
```

When working with a sequence of `Option<T, TException>` a similar method is provided, as well a way to extract all the exceptional values:

```csharp
var options = GetOptions(); // IEnumerable<Option<int, string>> { Some(1), None("error"), Some(2) }
var values = options.Values(); // IEnumerable<int> { 1, 2 }
var exceptions = options.Exceptions(); // IEnumerable<string> { "error" }
```
