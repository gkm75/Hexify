namespace Hexify

open System

type Mode = Encode | Decode

type Config = {
    Mode : Mode
    Bpl  : int  // Bytes per line
    Addr : bool
    InPath : string option
    OutPath : string option
}

module Config =

    let defaultConfig = { Mode = Encode; Bpl = 32; Addr = false; InPath = None; OutPath = None }

    let create operation bytesPerLine showAddress inputPath outputPath = 
        { Mode = operation; Bpl = bytesPerLine; Addr = showAddress; InPath = inputPath; OutPath = outputPath }

    let setMode operation cfg = {cfg with Mode = operation}

    let setBytesPerLine bytesPerLine cfg = {cfg with Bpl = bytesPerLine}

    let setShowAddress showAddress cfg = {cfg with Addr = showAddress}

    let setInputPath inputPath cfg = 
        let maybePath = if (String.IsNullOrWhiteSpace(inputPath)) then None else Some(inputPath)
        {cfg with InPath = maybePath}

    let setOutputPath outputPath cfg = 
        let maybePath = if (String.IsNullOrWhiteSpace(outputPath)) then None else Some(outputPath)
        {cfg with OutPath = maybePath}