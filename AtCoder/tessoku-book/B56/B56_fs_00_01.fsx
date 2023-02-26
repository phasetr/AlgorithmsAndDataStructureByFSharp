#r "nuget: FsUnit"
open FsUnit

(*
let N,Q,S,Ia = 11,3,"mississippi",[|(5,8);(6,10);(2,8)|]
let N,Q,S,Ia = 10,5,"aaaaaaaaaa",[|(1,10);(2,9);(3,8);(4,7);(5,6)|]
let N,Q,S,Ia = 100000,13,(Array.create 100000 'a' |> System.String),[|(4,99998);(5,99991);(11,99991);(8,99992);(7,99993);(11,99992);(5,99995);(2,99999);(7,99995);(2,99993);(6,99997);(4,99996);(1,99998)|]
*)
let solve N Q (S:string) Ia =
  let MOD = 998244353L
  let (.+) a b = (a+b)%MOD
  let (.*) a b = (a*b)%MOD
  let Sa = S |> Seq.toArray |> Array.map (fun c -> int64 c - 96L)
  let powa = (1L,[|0L..(int64 N)-1L|]) ||> Array.scan (fun p i -> p.*100L)
  let La,Ra =
    let La,Ra = Array.create (N+1) 0L,Array.create (N+1) 0L
    for i in 0..N-1 do
      La.[i+1] <- La.[i].*100L .+ Sa.[i]
      Ra.[i+1] <- Ra.[i].*100L .+ Sa.[N-1-i]
    La,Ra
  ([],Ia) ||> Array.fold (fun acc (l,r) ->
    let x = (La.[r]     - La.[l-1] .* powa.[r-l+1] + MOD) % MOD
    let y = (Ra.[N+1-l] - Ra.[N-r] .* powa.[r-l+1] + MOD) % MOD
    (if x=y then "Yes" else "No")::acc)
  |> List.rev

let N,Q = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0],x.[1])
let S = stdin.ReadLine()
let Ia = Array.init Q (fun _ -> stdin.ReadLine().Split() |> Array.map int |> fun x -> x.[0],x.[1])
solve N Q S Ia |> List.iter stdout.WriteLine

solve 11 3 "mississippi" [|(5,8);(6,10);(2,8)|] |> should equal ["Yes";"No";"Yes"]
solve 10 5 "aaaaaaaaaa" [|(1,10);(2,9);(3,8);(4,7);(5,6)|]
// max_02
solve 100000 13 (Array.create 100000 'a' |> System.String) [|(4,99998);(5,99991);(11,99991);(8,99992);(7,99993);(11,99992);(5,99995);(2,99999);(7,99995);(2,99993);(6,99997);(4,99996);(1,99998)|] |> should equal ["Yes";"Yes";"Yes";"Yes";"Yes";"Yes";"Yes";"Yes";"Yes";"Yes";"Yes";"Yes";"Yes"]
