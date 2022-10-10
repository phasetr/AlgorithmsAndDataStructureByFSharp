#r "nuget: FsUnit"
open FsUnit

let solve S =
  let rec group = function
    | [] -> []
    | x::xs ->
      let ys = List.takeWhile ((=) x) xs
      let zs = List.skipWhile ((=) x) xs
      (x::ys)::group zs
  let rec frec = function
    | [] -> []
    | a::b::s ->
      let xs = List.replicate (a-1) 0
      let ys = List.replicate (b-1) 0
      let x = (a+1)/2 + b/2
      let y = a/2 + (b+1)/2
      xs @ [x] @ [y] @ ys @ frec s
    | _ -> failwith "not come here"
  S |> List.ofSeq |> group |> List.map List.length |> frec

let S = stdin.ReadLine()
solve S |> List.map string |> String.concat " " |> stdout.WriteLine

solve "RRLRL" |> should equal [0;1;2;1;1]
solve "RRLLLLRLRRLL" |> should equal [0;3;3;0;0;0;1;1;0;2;2;0]
solve "RRRLLRLLRRRLLLLL" |> should equal [0;0;3;2;0;2;1;0;0;0;4;4;0;0;0;0]
