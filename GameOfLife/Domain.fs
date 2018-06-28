namespace GameOfLife

module Domain =
    open GameOfLife.Common.Domain

    type ExpectedLineCount = int
    type ExpectedLineLength = int
    type NonNegativeInteger = int
    type LineNumber = NonNegativeInteger
    type CharacterIndex = int
    type CharacterPosition = LineNumber*CharacterIndex
    
    type InputValidationError =
    | GenerationNameMissingOrEmpty
    | DimensionsMissing
    | DimensionsInvalid
    | MissingLines of ExpectedLineCount
    | TooManyLines of ExpectedLineCount
    | InvalidCharacter of char*CharacterPosition
    | LineWithWrongLength of LineNumber*ExpectedLineLength
    
    type GenerationInputError = 
    | Missing
    | TooManyArguments of int
    | NotFound of string
    | IOError of string*exn
    | Invalid of InputValidationError

    type Terminal =
    | WriteLine of string*Terminal
    | EndProgram

    type ConsoleArguments = string array
    type PathArgument = PathArgument of string
    type ValidatedPathArgument = ValidatedPathArgument of string
    type InputContent = InputContent of string seq
    type Output = Output of string list
    type GenerationInputResult = Result<Generation,GenerationInputError>
    
    type ReadConsoleInputArguments = ConsoleArguments -> Result<PathArgument,GenerationInputError>
    type ValidatePathArgument = PathArgument -> Result<ValidatedPathArgument,GenerationInputError>
    type ReadInput = ValidatedPathArgument -> Result<InputContent,GenerationInputError>
    type ValidateInput = InputContent -> Result<Generation,GenerationInputError>
    type StringifyGeneration = Generation -> Output
    type PrintResult = Result<Output,GenerationInputError> -> Terminal

