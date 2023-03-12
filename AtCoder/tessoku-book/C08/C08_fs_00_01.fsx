#r "nuget: FsUnit"
open FsUnit

(*
let N,Ia = 3,[|("2649",2);("4749",2);("2749",3)|]
let N,Ia = 2,[|(1234,3);(8894,2)|]
let N,Ia = 2,[|(1234,3);(8894,1)|]
*)
let solve N (Ia:(string*int)[]) =
  let diff X Y = (0,X,Y) |||> Seq.fold2 (fun acc x y -> if x=y then acc else acc+1) |> fun c -> min 3 (c+1)
  ([], [|0..9999|]) ||> Array.fold (fun acc i ->
    let x = i.ToString("0000")
    Ia |> Array.forall (fun (s,t) -> diff s x = t) |> fun b -> if b then x::acc else acc)
  |> fun xs -> if xs.Length = 1 then List.head xs else "Can't Solve"
let N = stdin.ReadLine() |> int
let Ia = Array.init N (fun _ -> stdin.ReadLine().Split() |> fun x -> x.[0],int x.[1])
solve N Ia |> stdout.WriteLine

solve 3 [|("2649",2);("4749",2);("2749",3)|] |> should equal "4649"
solve 2 [|("1234",3);("8894",2)|] |> should equal "Can't Solve"
solve 2 [|("1234",3);("8894",1)|] |> should equal "8894"
