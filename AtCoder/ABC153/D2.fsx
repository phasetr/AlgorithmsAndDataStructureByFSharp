#r "nuget: FsUnit"
open System
open System.IO
open FsUnit

let rec solve = function
    | 1L -> 1L
    | n -> 2L * solve (n/2L) + 1L

solve 2L |> should equal 3L
solve 3L |> should equal 3L
solve 4L |> should equal 7L
solve 1000000000000L |> should equal 1099511627775L
