#r "nuget: FsUnit"
open FsUnit

(*
let T,Ia = 3,[|(1,2,3);(2,3,4);(3,4,5)|]
*)
let solve T Ia =
  let Xa = Array.create 20 0
  let score = Xa |> Array.sumBy (fun ai -> if ai=0 then 1 else 0)
  let A (p,q,r) = Xa.[p-1] <- Xa.[p-1]+1; Xa.[q-1] <- Xa.[q-1]+1; Xa.[r-1] <- Xa.[r-1]+1
  let B (p,q,r) = Xa.[p-1] <- Xa.[p-1]-1; Xa.[q-1] <- Xa.[q-1]-1; Xa.[r-1] <- Xa.[r-1]-1
  let ret = Array.create T 'A'

  Ia |> Array.iteri (fun i pqr ->
    A pqr
    let score_a = score
    B pqr
    B pqr
    let score_b = score
    A pqr
    if score_b < score_a then A pqr
    else B pqr; ret.[i] <- 'B')
  ret

let T = stdin.ReadLine() |> int
let Ia = Array.init T (fun _ -> stdin.ReadLine().Split() |> Array.map int |> fun x -> x.[0],x.[1],x.[2])
solve T Ia |> Array.iter stdout.WriteLine

solve 3 [|(1,2,3);(2,3,4);(3,4,5)|]
