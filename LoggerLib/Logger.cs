using System;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace LoggerLib;

public class Logger
{
    public void Log(string message, [CallerMemberName] object? callerMemberName = null, [CallerFilePath] object? sourceFilePath = null, [CallerLineNumber] int sourceLineNumber = 0)
    {
        var dict = new ArgumentDictionary(0);
        
        LogWithArguments(message, dict, callerMemberName, sourceFilePath, sourceLineNumber);
        
    }

    public void Log<T1>(string message, T1 arg1, [CallerArgumentExpression(nameof(arg1))] object? arg1Name = null, [CallerMemberName] object? callerMemberName = null, [CallerFilePath] object? sourceFilePath = null, [CallerLineNumber] int sourceLineNumber = 0)
    {
        var dict = new ArgumentDictionary(1)
        {
            {arg1Name, arg1}
        };

        LogWithArguments(message, dict, callerMemberName, sourceFilePath, sourceLineNumber);
    }

    public void Log<T1, T2>(string message, T1 arg1, T2 arg2, [CallerArgumentExpression(nameof(arg1))] object? arg1Name = null,[CallerArgumentExpression(nameof(arg2))] object? arg2Name = null, [CallerMemberName] object? callerMemberName = null, [CallerFilePath] object? sourceFilePath = null, [CallerLineNumber] int sourceLineNumber = 0)
    {
        var dict = new ArgumentDictionary(2)
        {
            {arg1Name, arg1},
            {arg2Name, arg2},
        };

        LogWithArguments(message, dict, callerMemberName, sourceFilePath, sourceLineNumber);
    }

    public void Log<T1, T2, T3>(string message, T1 arg1, T2 arg2, T3 arg3, [CallerArgumentExpression(nameof(arg1))] object? arg1Name = null, [CallerArgumentExpression(nameof(arg2))] object? arg2Name = null, [CallerArgumentExpression(nameof(arg3))] object? arg3Name = null, [CallerMemberName] object? callerMemberName = null, [CallerFilePath] object? sourceFilePath = null, [CallerLineNumber] int sourceLineNumber = 0)
    {
        var dict = new ArgumentDictionary(3)
        {
            {arg1Name, arg1},
            {arg2Name, arg2},
            {arg3Name, arg3},
        };

        LogWithArguments(message, dict, callerMemberName, sourceFilePath, sourceLineNumber);
    }

    private void LogWithArguments(string message, ArgumentDictionary dict, object? callerMemberName, object? sourceFilePath, int sourceLineNumber)
    {
        var data = JsonSerializer.Serialize(dict);

        Console.WriteLine(message + $". CallerMethod: {callerMemberName}, CallerLineNumber: {sourceLineNumber}: " + data);
    }
}