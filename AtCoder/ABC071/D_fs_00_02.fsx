#r "nuget: FsUnit"
open FsUnit

(*
let N,S1,S2 = 3,"aab","ccb"
let N,S1,S2 = 1,"Z","Z"
let N,S1,S2 = 52,"RvvttdWIyyPPQFFZZssffEEkkaSSDKqcibbeYrhAljCCGGJppHHn","RLLwwdWIxxNNQUUXXVVMMooBBaggDKqcimmeYrhAljOOTTJuuzzn"
*)
let solve N (S1:string) (S2:string) =
  let MOD = 1_000_000_007L
  let (.*) x y = (x*y)%MOD

  let rec frec p = function
    | [] -> p
    | [false] -> p.*6L
    | [true] -> p.*3L
    | false::false::xs -> frec (p.*3L) (false::xs)
    | false::true::xs  -> frec (p.*2L) (true::xs)
    | true::false::xs  -> frec p       (false::xs)
    | true::true::xs   -> frec (p.*2L) (true::xs)

  [0..N-1]
  |> List.map (fun i -> S1.[i]=S2.[i])
  |> frec 1L

let N = stdin.ReadLine() |> int
let S1 = stdin.ReadLine()
let S2 = stdin.ReadLine()
solve N S1 S2 |> stdout.WriteLine

solve 3 "aab" "ccb" |> should equal 6
solve 1 "Z" "Z" |> should equal 3
solve 52 "RvvttdWIyyPPQFFZZssffEEkkaSSDKqcibbeYrhAljCCGGJppHHn" "RLLwwdWIxxNNQUUXXVVMMooBBaggDKqcimmeYrhAljOOTTJuuzzn" |> should equal 958681902
