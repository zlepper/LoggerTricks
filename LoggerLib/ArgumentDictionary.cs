using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LoggerLib;

internal class ArgumentDictionary : IReadOnlyDictionary<string, object?>
{
    private readonly KeyValuePair<string, object?>[] _values;
    private int _nextArgumentNumber;

    public ArgumentDictionary(int count)
    {
        _values = new KeyValuePair<string, object?>[count];
    }

    public void Add(object? argumentName, object? value)
    {
        var argumentNameString = argumentName?.ToString() ?? $"arg{_nextArgumentNumber + 1}";
        _values[_nextArgumentNumber++] = new KeyValuePair<string, object?>(argumentNameString, value);
    }

    public IEnumerator<KeyValuePair<string, object?>> GetEnumerator()
    {
        return _values.AsEnumerable().GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public int Count => _values.Length;
    
    public bool ContainsKey(string key)
    {
        return _values.Any(v => v.Key == key);
    }

    public bool TryGetValue(string key, out object? value)
    {
        foreach (var pair in _values)
        {
            if (pair.Key == key)
            {
                value = pair.Value;
                return true;
            }
        }

        value = default;
        return false;
    }

    public object? this[string key] => TryGetValue(key, out var v) ? v : default;

    public IEnumerable<string> Keys => _values.Select(pair => pair.Key);
    public IEnumerable<object?> Values => _values.Select(pair => pair.Value);
}