#r "nuget: FsUnit"
open FsUnit

let solve a b c d e f As =
  let dice = a,b,c,d,e,f
  let rightSide (a,b,c,d,e,f) pair =
    let find l = List.fold (fun acc p -> acc || p=pair) false l
    if find [b,c;c,e;d,b;e,d] then a
    else if find [a,d;c,a;d,f;f,c] then b
    else if find [a,b;b,f;e,a;f,e] then c
    else if find [a,e;b,a;e,f;f,b] then d
    else if find [a,c;c,f;d,a;f,d] then e
    else f
  let rec loop acc = function
    | [] -> List.rev acc
    | hd::tl -> loop ((rightSide dice hd) :: acc) tl
  loop [] As

let [|a;b;c;d;e;f|] = stdin.ReadLine().Split() |> Array.map int
let N = stdin.ReadLine() |> int
let As = [ for i in 1..N do (stdin.ReadLine() |> int) ]
solve a b c d e f As |> Array.map string |> String.concat "\n" |> stdout.WriteLine

let a,b,c,d,e,f = 1,2,3,4,5,6
let As = [(6,5);(1,3);(3,2)]
solve a b c d e f As |> should equal [3;5;6]
