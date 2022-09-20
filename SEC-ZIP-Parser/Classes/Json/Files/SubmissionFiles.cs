using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using SEC_ZIP_Parser.Classes.Helpers;

namespace SEC_ZIP_Parser.Classes.Json.Files;

public readonly struct SubmissionFiles
{
    
    private readonly IEnumerable<string> _filePaths;

    public IEnumerable<string> FilePaths => _filePaths;

    public int Length => _filePaths.Count();

    public SubmissionFiles(string directoryPath) : this()
    {
        _filePaths = Directory.EnumerateFiles(directoryPath)
            .AsParallel()
            .WithDegreeOfParallelism(3)
            .AsUnordered()
            .Where(path => path.EndsWith(".json"))
            .Where(path => path.Contains("submissions"))
            .Where(path => !FileHelper.GetFileName(path).Contains("submissions"))
            .AsSequential();
    }
}