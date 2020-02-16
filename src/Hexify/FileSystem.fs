namespace Hexify

open System.IO

module FileSystem =

    let readText filePath =
        try
            File.ReadAllLines(filePath) |> Ok
        with
        | e -> Error(ErrorHandling.ErrorCode.FileError, e.Message)

    let readBinary filePath =
        try
            File.ReadAllBytes(filePath) |> Ok
        with
        | e -> Error(ErrorHandling.ErrorCode.FileError, e.Message)

    let writeText filePath txt =
        try
            File.WriteAllText(filePath, txt) 
            Ok ()
        with
        | e -> Error(ErrorHandling.ErrorCode.FileError, e.Message)

    let writeBinary filePath bin =
        try
            File.WriteAllBytes(filePath, bin)
            Ok ()
        with
        | e -> Error(ErrorHandling.ErrorCode.FileError, e.Message)