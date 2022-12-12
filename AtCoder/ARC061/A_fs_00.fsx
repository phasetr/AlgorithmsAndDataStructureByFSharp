#r "nuget: FsUnit"
open FsUnit

(*
let S = "125"
let S = "9999999999"
*)
let solve (S:string) =
  let rec frec a y = function
    | [] -> a+y
    | x::xs -> frec (a+y) x xs + frec a (y*10L + x) xs
  let ys = S |> Seq.map (fun c -> int64 c - int64 '0') |> Seq.toList
  frec 0L (List.head ys) (List.tail ys)

let S = stdin.ReadLine()
solve S |> stdout.WriteLine

solve "125" |> should equal 176L
solve "9999999999" |> should equal 12656242944L
