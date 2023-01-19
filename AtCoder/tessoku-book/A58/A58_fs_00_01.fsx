#r "nuget: FsUnit"
open FsUnit

(*
let N,Q,Qa = 8,4,[|(1,3,16);(2,4,7);(1,5,13);(2,4,7)|]
*)
let solve N Q Qa =
  let rec size acc = if N<=acc then acc else size (2*acc)
  let replace pos x (st:int[]) =
    let mutable i = st.Length/2 + pos - 1
    st.[i] <- x
    while i>1 do i<-i/2; st.[i] <- max st.[2*i] st.[2*i+1]
    st
  let sup l r (st:int[]) =
    let rec frec l r a b i =
      if l<=a && b<=r then st.[i]
      elif b<=l || r<=a then 0
      else
        let m = (a+b)/2
        max (frec l r a m (2*i)) (frec l r m b (2*i+1))
    frec l r 1 (st.Length/2+1) 1

  (Array.create (2*size 1) 0, Qa)
  ||> Array.fold (fun st (i,pl,xr) ->
    if i=1 then st |> replace pl xr
    else (st |> sup pl xr |> stdout.WriteLine); st)

let N,Q = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0],x.[1])
let Qa = Array.init Q (fun _ -> stdin.ReadLine().Split() |> Array.map int |> fun x -> x.[0],x.[1],x.[2])
solve N Q Qa

solve 8 4 [|(1,3,16);(2,4,7);(1,5,13);(2,4,7)|]
(*
0
13
*)
