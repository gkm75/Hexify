namespace Hexify

open System

type Mode = Encode | Decode

type Config = {
    mode : Mode
    bpl  : int  // Bytes per line
    addr : bool
    inPath : string option
    outPath : string option
}

module Config =

    let defaultConfig = { mode = Encode; bpl = 16; addr = false; inPath = None; outPath = None }

    let create operation bytesPerLine showAddress inputPath outputPath = 
        { mode = operation; bpl = bytesPerLine; addr = showAddress; inPath = inputPath; outPath = outputPath }

    let setBytesPerLine bytesPerLine cfg = {cfg with bpl = bytesPerLine}

    let setShowAddress showAddress cfg = {cfg with addr = showAddress}

    let setInputPath inputPath cfg = 
        let maybePath = if (String.IsNullOrWhiteSpace(inputPath)) then None else Some(inputPath)
        {cfg with inPath = maybePath}