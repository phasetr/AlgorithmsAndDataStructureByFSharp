#r "nuget: FsUnit"
open FsUnit

(*
let N,Q,Qa = 8,4,[|(1,3,16);(1,6,24);(2,4,8);(2,1,7)|]
*)
let solve N Q Qa =
  let length k = if k=0 then 0 else let rec frec acc = if k<=acc then acc else frec (2*acc) in frec 1
  let create k v = Array.create (2*length k) v
  let update f k x (st:'a[]) =
    let mutable i = st.Length/2 + k - 1
    st.[i] <- x
    while i>1 do i<-i/2; st.[i] <- f st.[2*i] st.[2*i+1]
    st
  let fold f l r v (st:int[]) =
    let left k = 2*k
    let right k = 2*k+1
    let rec frec l r a b i =
      if l<=a && b<=r then st.[i]
      elif b<=l || r<=a then v
      else let m = (a+b)/2 in f (frec l r a m (left i)) (frec l r m b (right i))
    frec l r 1 (st.Length/2+1) 1
  (Array.create (2*length N) 0, Qa)
  ||> Array.fold (fun st (i,pl,xr) ->
    if i=1 then st |> update (+) pl xr
    else (st |> fold (+) pl xr 0 |> stdout.WriteLine; st))

let N,Q = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0],x.[1])
let Qa = Array.init Q (fun _ -> stdin.ReadLine().Split() |> Array.map int |> fun x -> x.[0],x.[1],x.[2])
solve N Q Qa

solve 8 4 [|(1,3,16);(1,6,24);(2,4,8);(2,1,7)|]
(*
24
40
*)
