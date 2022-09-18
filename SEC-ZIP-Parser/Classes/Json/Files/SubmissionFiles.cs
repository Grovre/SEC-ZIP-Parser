using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;

namespace SEC_ZIP_Parser.Classes.Json.Files;

public readonly struct SubmissionFiles
{
    private readonly string[] _filePaths;

    public string this[int i] => _filePaths[i];

    public int Length => _filePaths.Length;

    public SubmissionFiles(string directoryPath) : this()
    {
        _filePaths = Directory.EnumerateFiles(directoryPath)
            .AsParallel()
            .WithDegreeOfParallelism(3)
            .AsUnordered()
            .Where(path => path.EndsWith(".json"))
            .Where(path => path.Contains("submissions"))
            .ToArray();
    }
}