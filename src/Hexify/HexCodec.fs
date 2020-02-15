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

    let encode config =
        // match config.InPath with
        // | Some path -> 
        // | None ->

        let input = FileSystem.readBinary (inFile)
        Error (-1, "broken")

    let decode config = 
        Ok 0