open System
open Hexify

let usage() =
    printfn "Usage: Hexify [-e] [-d] [-a] [-n] [-b num] [-i inputPath] [-o outputPath]"
    printfn ""
    printfn "where;"
    printfn "[-e]\t\tEncode"
    printfn "[-d]\t\tDecode"
    printfn "[-a]\t\tShow address"
    printfn "[-n]\t\tHide address"
    printfn "[-b num]\tBytes per line"
    printfn "[-i inputPath]\tThe input path / file"
    printfn "[-o outputPath]\tThe output path / file"

let rec parseArgs cfg = function
    | [] -> cfg
    | "-d"::xs -> parseArgs (Config.setMode Mode.Decode cfg) xs
    | "-e"::xs -> parseArgs (Config.setMode Mode.Encode cfg) xs
    | "-i"::fn::xs -> parseArgs (Config.setInputPath fn cfg) xs
    | "-o"::fn::xs -> parseArgs (Config.setOutputPath fn cfg) xs
    | "-a"::xs -> parseArgs (Config.setShowAddress true cfg) xs
    | "-n"::xs -> parseArgs (Config.setShowAddress false cfg) xs
    | "-b"::b::xs ->
        let bpl = Int32.Parse(b)
        parseArgs (Config.setBytesPerLine bpl cfg) xs
    | "-h"::_ | _-> 
            usage()
            exit(0) 

[<EntryPoint>]
let main argv =
    printfn "Hexify - (c) 2020 Gordon Mangion"
    
    let cfg = parseArgs Config.defaultConfig [for c in argv -> c]

    let statCode = match cfg.Mode with
                   | Encode -> HexCodec.encode cfg
                   | Decode -> HexCodec.decode cfg

    match statCode with
    | Ok _ -> 
        printfn "Done"
        0

    | Error (code, msg:string) ->
        let cd = int(code)
        Console.Error.Write (ErrorHandling.ErrorStrings.[-1 * cd])
        Console.Error.WriteLine (msg)
        cd
