namespace SEC_ZIP_Parser.Classes.Interfaces;

public interface IParser<T>
{
    public void ParseTo(ref T o);
}