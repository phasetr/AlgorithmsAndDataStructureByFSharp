#r "../packages/NUnit/lib/netstandard2.0/nunit.framework.dll"
#r "../packages/FsUnit/lib/netstandard2.0/FsUnit.NUnit.dll"
#r "../packages/FSharp.Core/lib/netstandard2.0/FSharp.Core.dll"
open NUnit.Framework
open FsUnit

// cf. https://qiita.com/7shi/items/1e2a66bf8e8c7f0bd70f
module Bubble1 =
    /// Move the min value to rightmost.
    let rec bswap xs =
        match xs with
        | x :: y :: zs when x < y -> y :: bswap (x :: zs)
        | _ -> xs

    /// bubble sort
    let rec bsort lst =
        match lst with
        | [] -> []
        | xs ->
            let ys = xs |> bswap |> List.rev
            (List.head ys) :: bsort (List.tail ys)

// test
[ 1; 2; 3; 4; 5 ] |> Bubble1.bswap |> should equal [2;3;4;5;1]
[ 5; 4; 3; 2; 1 ] |> Bubble1.bsort |> should equal [1;2;3;4;5]
