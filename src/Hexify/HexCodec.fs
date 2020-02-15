namespace Hexify

open System
open System.Text
open System.Collections.Generic

open Config

module HexCodec =

    let private hexStr = "0123456789abcdef"

    let private binToHex (v:int) (strBld:StringBuilder) = 
        let hi = (v >>> 4) &&& 0x0f
        let lo = v &&& 0x0f
        strBld.Append(hexStr.[hi]).Append(hexStr.[lo]) |> ignore

    let private HexToBin (hc:char) (lc:char) (bl:IList<byte>) = 
        let hi = hexStr.IndexOf(hc)
        let lo = hexStr.IndexOf(lc)
        if hi = -1 || lo = -1 then
            raise (Exception(sprintf "Invalid character at offset %i" (bl.Count)))
        else
            let v = byte((hi <<< 4) ||| lo)
            bl.Add(v)        


    let private checkConfigAndExecute config action =
        match config.inPath with
        | Some inPath ->
            match config.outPath with
            | Some outPath -> action (inPath, outPath)
            | None ->
                Error (ErrorHandling.ErrorCode.ConfigError, "output path is none") 
        | None ->
            Error (ErrorHandling.ErrorCode.ConfigError, "input path is none")


    let encode config =
        let encoder (inFile, outFile) =
            match FileSystem.readBinary inFile with
            | Ok bytes ->
                let byteLines = bytes |> List.ofArray |> List.chunkBySize config.bpl
                let txt = "hello"
                FileSystem.writeText outFile txt
            | Error (code, msg) ->
                Error (code, msg)
        
        checkConfigAndExecute config encoder
        
        
    let decode config = 
        Ok ()