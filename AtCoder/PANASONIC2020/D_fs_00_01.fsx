#r "nuget: FsUnit"
open FsUnit

// let N = 2
// let N = 3
let solve N =
  let succ (c:char) = int c |> (+) 1 |> char
  let m xs = List.max xs |> succ
  let rec frec n =
    if n=1 then [['a']]
    else frec (n-1) |> List.collect (fun xs -> ['a'..(m xs)] |> List.map (fun c -> c::xs))
  frec N |> List.map (List.rev >> System.String.Concat)

let N = stdin.ReadLine() |> int
solve N |> List.iter stdout.WriteLine

solve 1 |> should equal ["a"]
solve 2 |> should equal ["aa";"ab"]
