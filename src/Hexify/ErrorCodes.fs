namespace Hexify

module ErrorHandling =

    type ErrorCode = 
        | NoErrors = 0
        | FileError = -1
        | EncodeError = -2
        | DecodeError = -3
        | UnknownError = -4

    let ErrorStrings = [|
        "[Hexify] OK ";
        "[Hexify] FileError occured: ";
        "[Hexify] Encoding Error occured: ";
        "[Hexify] Decoding Error occured: ";
        "[Hexify] Unknown Error occured: " |]
