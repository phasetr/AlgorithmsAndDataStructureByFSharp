#r "nuget: FsUnit"
open FsUnit

(*
let N,Ia = 3,[|(2649,2);(4749,2);(2749,3)|]
let N,Ia = 2,[|(1234,3);(8894,2)|]
let N,Ia = 2,[|(1234,3);(8894,1)|]
*)
let solveWA N (Ia:(int*int)[]) =
  let nDigit n x = let k = pown 10 n in (x%(k*10))/k
  let rec frec acc i =
    if i=10000 then acc
    else
      let num = i.ToString("0000") |> Seq.map (fun c -> int c - 48) |> Seq.toArray
      Ia |> Array.forall (fun (s,t) ->
        let diff =
          (0,[|0..3|]) ||> Array.fold (fun acc c -> if nDigit c s = num.[3-c] then acc else acc+1)
          |> fun x -> if x=0 then 1 elif x=1 then 2 else 3
        diff=t)
      |> fun b ->
        if b then match acc with | None -> Some (string i) | _ -> Some "Can't Solve" else acc
        |> function
          | Some s -> if s="Can't Solve" then Some s else frec (Some s) (i+1)
          | o -> frec o (i+1)
  frec (None: string option) 0 |> Option.get

let N = stdin.ReadLine() |> int
let Ia = Array.init N (fun _ -> stdin.ReadLine().Split() |> Array.map int |> fun x -> x.[0],x.[1])
solve N Ia |> stdout.WriteLine

solve 3 [|(2649,2);(4749,2);(2749,3)|] |> should equal "4649"
solve 2 [|(1234,3);(8894,2)|] |> should equal "Can't Solve"
solve 2 [|(1234,3);(8894,1)|] |> should equal "8894"
