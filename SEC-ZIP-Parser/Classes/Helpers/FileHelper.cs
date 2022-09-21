using System.Text;

namespace SEC_ZIP_Parser.Classes.Helpers;

public static class FileHelper
{
    public static string GetFileName(string path)
    {
        var lastPathSeparator = path.LastIndexOf('\\');
        return path[(lastPathSeparator + 1)..];
    }

    public static string RemoveFileExtension(string fileName)
    {
        var prepending = fileName.Split('.');
        var length = fileName.Length - prepending[^1].Length;
        var sb = new StringBuilder(length);
        for (var i = 0; i < prepending.Length - 1; i++)
        {
            sb.Append(prepending[i]);
        }

        return sb.ToString();
    }
}