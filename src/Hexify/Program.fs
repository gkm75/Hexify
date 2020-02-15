open System
open Hexify

let parseArgs argv =
    Config.defaultConfig


[<EntryPoint>]
let main argv =

    let cfg = parseArgs argv

    let statCode = match cfg.mode with
                   | Encode -> HexCodec.encode cfg
                   | Decode -> HexCodec.decode cfg

    match statCode with
    | Ok _ -> 
        printfn "Done"
        0

    | Error (code, msg:string) ->
        Console.Error.Write (ErrorHandling.ErrorStrings.[-1 * code])
        Console.Error.WriteLine (msg)
        code

