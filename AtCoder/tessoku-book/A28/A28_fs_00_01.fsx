#r "nuget: FsUnit"
open FsUnit

(*
let N,Ia = 4,[|("+",57);("+",43);("*",100);("-",1)|]
*)
let solve N Ia =
  let p a = let MOD = 10000 in (a+MOD)%MOD
  ((Array.create (N+1) 0, 1), Ia)
  ||> Array.fold (fun (acc,i) (op,a) ->
    Array.set acc i ((if op="+" then acc.[i-1]+a elif op="-" then acc.[i-1]-a else acc.[i-1]*a) |> p)
    (acc,i+1))
  |> fst |> Array.tail

let N = stdin.ReadLine() |> int
let Ia = Array.init N (fun _ -> stdin.ReadLine().Split() |> fun x -> x.[0],int x.[1])
solve N Ia |> Array.iter stdout.WriteLine

solve 4 [|("+",57);("+",43);("*",100);("-",1)|] |> should equal [|57;100;0;9999|]
