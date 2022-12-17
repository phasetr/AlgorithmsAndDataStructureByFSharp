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
  let isVertical i = S1.[i]=S2.[i]
  let rec frec acc i =
    if i=N then acc
    elif i=0 then if isVertical i then frec (acc.*3L) (i+1) else frec (acc.*6L) (i+2)
    else
      match isVertical (i-1),isVertical i with
        | true, true  -> frec (acc.*2L) (i+1)
        | false,true  -> frec acc       (i+1)
        | true, false -> frec (acc.*2L) (i+2)
        | false,false -> frec (acc.*3L) (i+2)
  frec 1L 0

let N = stdin.ReadLine() |> int
let S1 = stdin.ReadLine()
let S2 = stdin.ReadLine()
solve N S1 S2 |> stdout.WriteLine

solve 3 "aab" "ccb" |> should equal 6
solve 1 "Z" "Z" |> should equal 3
solve 52 "RvvttdWIyyPPQFFZZssffEEkkaSSDKqcibbeYrhAljCCGGJppHHn" "RLLwwdWIxxNNQUUXXVVMMooBBaggDKqcimmeYrhAljOOTTJuuzzn" |> should equal 958681902
