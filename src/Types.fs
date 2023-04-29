module Types

[<RequireQualifiedAccess>]
type Pages =
  | Landing
  | Search
  | Movie of string
