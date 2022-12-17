#r "nuget: FsUnit"
open FsUnit

(*
let N,S1,S2 = 3,"aab","ccb"
let N,S1,S2 = 1,"Z","Z"
let N,S1,S2 = 52,"RvvttdWIyyPPQFFZZssffEEkkaSSDKqcibbeYrhAljCCGGJppHHn","RLLwwdWIxxNNQUUXXVVMMooBBaggDKqcimmeYrhAljOOTTJuuzzn"
*)
let solve N (S1:string) =
  let MOD = 1_000_000_007L
  let (.*) x y = (x*y)%MOD

  let rec group = function
    | [] -> []
    | x::xs -> let ys = List.takeWhile ((=) x) xs in let zs = List.skipWhile ((=) x) xs in (x::ys)::group zs
  let f acc = function
    | (1,1) -> acc.*2L
    | (1,2) -> acc.*2L
    | (2,1) -> acc
    | _     -> acc.*3L

  let patterns = S1 |> Seq.toList |> group |> List.map (List.length)
  let hp = List.head patterns
  List.pairwise patterns |> List.fold f (if hp=1 then 3L else 6L)

let N = stdin.ReadLine() |> int
let S1 = stdin.ReadLine()
solve N S1 |> stdout.WriteLine

solve 3 "aab" |> should equal 6
solve 1 "Z" |> should equal 3
solve 52 "RvvttdWIyyPPQFFZZssffEEkkaSSDKqcibbeYrhAljCCGGJppHHn" |> should equal 958681902
