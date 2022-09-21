using System.Collections.Generic;

namespace SEC_ZIP_Parser.Classes.Json.Parsing;

public class SafePropertyValue<T>
{

    public static readonly int ErrorInt = -1;
    
    #nullable enable
    public bool KeyNotFound { get; }
    public KeyNotFoundException? GeneratedException { get; }
    public T? RetrievedValue { get; }

    public SafePropertyValue(T? retrievedValue, KeyNotFoundException? exception = null)
    {
        GeneratedException = exception;
        KeyNotFound = GeneratedException != null;
        RetrievedValue = retrievedValue;
    }
}