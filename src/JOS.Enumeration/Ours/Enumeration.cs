using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace JOS.Enumeration.Ours;

public abstract class Enumeration : IComparable
{
    public const int MaxDescriptionLength = 128;

    protected Enumeration() { Description = string.Empty; }

    protected Enumeration(int value, string description)
    {
        if (value < -1 || value == 0)
        {
            throw new Exception(
                $"Invalid value: {value}. Please use -1 to represent a null value and positive values otherwise.");
        }

        Value = value;

        if (description.Length > MaxDescriptionLength)
        {
            throw new Exception($"Display name can be max {MaxDescriptionLength} characters");
        }

        Description = description;
    }

    public int Value { get; }

    public string Description { get; }

    public string GetName<T>() where T : Enumeration, new()
    {
        var type = typeof(T);
        var fields = type.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly);

        foreach (var info in fields)
        {
            var instance = new T();
            var locatedValue = info.GetValue(instance) as T;
            if (locatedValue?.Value == Value)
            {
                return info.Name;
            }
        }
        throw new Exception($"The enumeration value {Value} could not be found");
    }

    public override string ToString()
    {
        return Description;
    }

    public static IEnumerable<T> GetAll<T>() where T : Enumeration
    {
        var type = typeof(T);
        var fields = type.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly);

        foreach (var info in fields)
        {
            if (info.GetValue(null) is T locatedValue)
            {
                yield return locatedValue;
            }
        }
    }

    public override bool Equals(object? obj)
    {
        if (!(obj is Enumeration otherValue))
        {
            return false;
        }

        var typeMatches = GetType() == obj.GetType();
        var valueMatches = Value.Equals(otherValue.Value);

        return typeMatches && valueMatches;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Value);
    }

    public static bool Exists<T>(int value) where T : Enumeration, new()
    {
        var matchingItem = GetMatchingItem<T>(item => item.Value == value);
        return matchingItem != null;
    }

    public static bool Exists<T>(string description) where T : Enumeration, new()
    {
        var matchingItem = GetMatchingItem<T>(item => item.Description == description);
        return matchingItem != null;
    }

    public static T FromValue<T>(int value) where T : Enumeration
    {
        var matchingItem = Parse<T, int>(value, "value", item => item.Value == value);
        return matchingItem;
    }

    public static Result<T> Parse<T>(int value) where T : Enumeration
    {
        var matchingItem = GetMatchingItem<T>(item => item.Value == value);

        if (matchingItem == null)
        {
            return Result.Failure<T>(
                new Error(ErrorTypes.Validation, $"'{value}' is not a valid value in {typeof(T)}"));
        }
        return Result.Success(matchingItem);
    }

    public static T FromDescription<T>(string description) where T : Enumeration
    {
        var matchingItem = Parse<T, string>(description, "description", item => item.Description == description);
        return matchingItem;
    }

    private static T Parse<T, TK>(TK value, string description, Func<T, bool> predicate) where T : Enumeration
    {
        var matchingItem = GetMatchingItem(predicate);

        if (matchingItem == null)
        {
            var message = $"'{value}' is not a valid {description} in {typeof(T)}";
            throw new Exception(message);
        }

        return matchingItem;
    }

    public static T? GetMatchingItem<T>(Func<T, bool> predicate) where T : Enumeration
    {
        return GetAll<T>().FirstOrDefault(predicate);
    }

    public int CompareTo(object? other)
    {
        if (!(other is Enumeration e))
        {
            throw new ArgumentException("obj is not the same type as this instance");
        }
        return Value.CompareTo(e.Value);
    }
}
