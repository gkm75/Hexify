namespace Hexify

module ErrorHandling =

    type ErrorCode = 
        | NoErrors = 0
        | ConfigError = -1
        | FileError = -2
        | EncodeError = -3
        | DecodeError = -4
        | UnknownError = -5

    let ErrorStrings = [|
        "[Hexify] OK ";
        "[Hexify] ConfigError occured: ";
        "[Hexify] FileError occured: ";
        "[Hexify] Encoding Error occured: ";
        "[Hexify] Decoding Error occured: ";
        "[Hexify] Unknown Error occured: " |]
