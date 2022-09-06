#r "nuget: FsUnit"
open FsUnit

let solve N Xa Ya =
  let pres = Xa |> Array.toList
  let ins = Ya |> Array.toList
  let splitMaybe k xs =
    let rec f k ys = function
      | [] -> None
      | z::zs -> if k=z then Some (List.rev ys, k, zs) else f k (z::ys) zs
    f k [] xs
  let rec post pres ins =
    match (pres,ins) with
      | (_,[]) -> []
      | ([],_) -> []
      | _ ->
        let (l,p,r) =
          List.map (fun p -> splitMaybe p ins) pres
          |> List.filter Option.isSome |> List.head |> Option.get
        post pres l @ post pres r @ [p]
  post pres ins

let N = stdin.ReadLine() |> int
let Xa = stdin.ReadLine().Split() |> Array.map int
let Ya = stdin.ReadLine().Split() |> Array.map int
solve N Xa Ya |> List.map string |> String.concat " " |> stdout.WriteLine

let N,Xa,Ya = 5,[|1..5|],[|3;2;4;1;5|]
solve N Xa Ya |> should equal [3;4;2;5;1]
solve 4 [|1..4|] [|1..4|] |> should equal [4;3;2;1]
