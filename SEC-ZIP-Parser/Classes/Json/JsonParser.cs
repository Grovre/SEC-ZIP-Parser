using System.Collections.Generic;
using System.Text.Json;
using SEC_ZIP_Parser.Classes.Interfaces;

namespace SEC_ZIP_Parser.Classes.Json;

public abstract class JsonParser<T> : IParser<T>
{
    public string JsonFilePath { get; }
    
    public abstract T Parse();
    
    public abstract void ParseTo(ref T dst);

    protected JsonParser(string jsonFilePath)
    {
        JsonFilePath = jsonFilePath;
    }

#nullable enable
    public SafePropertyValue<string> SafeStringRetrievalFromProperty(JsonElement root, params string[]? propertyNames)
    {
        try
        {
            if (propertyNames != null)
            {
                root = AdvanceElementThroughProperties(root, propertyNames);
            }
            
            var str = root.GetString();
            return new SafePropertyValue<string>(str);
        }
        catch (KeyNotFoundException e)
        {
            return new SafePropertyValue<string>(null, e);
        }
    }
    
    public SafePropertyValue<int> SafeIntRetrievalFromProperty(JsonElement root, params string[]? propertyNames)
    {
        try
        {
            if (propertyNames != null)
            {
                root = AdvanceElementThroughProperties(root, propertyNames);
            }

            var n = root.GetInt32();
            return new SafePropertyValue<int>(n);
        }
        catch (KeyNotFoundException e)
        {
            return new SafePropertyValue<int>(SafePropertyValue<int>.ErrorInt, e);
        }
    }

    private JsonElement AdvanceElementThroughProperties(JsonElement root, string[] propertyNames)
    {
        foreach (var propertyName in propertyNames)
        {
            root = root.GetProperty(propertyName);
        }

        return root;
    }
}