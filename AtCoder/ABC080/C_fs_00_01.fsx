#r "nuget: FsUnit"
open FsUnit

(*
let N,Fa,Pa = 1,[|[|1;1;0;1;0;0;0;1;0;1|]|],[|[|3;4;5;6;7;8;9;-2;-3;4;-2|]|]
let N,Fa,Pa = 2,[|[|1;1;1;1;1;0;0;0;0;0|];[|0;0;0;0;0;1;1;1;1;1|]|],[|[|0;-2;-2;-2;-2;-2;-1;-1;-1;-1;-1|];[|0;-2;-2;-2;-2;-2;-1;-1;-1;-1;-1|]|]
let N,Fa,Pa = 3,[|[|1;1;1;1;1;1;0;0;1;1|];[|0;1;0;1;1;1;1;0;1;0|];[|1;0;1;1;0;1;0;1;0;1|]|],[|[|-8;6;-2;-8;-8;4;8;7;-6;2;2|];[|-9;2;0;1;7;-5;0;-2;-6;5;5|];[|6;-6;7;-9;6;-5;8;0;-9;-7;-7|]|]
*)
let solve N (Fa:int[][]) (Pa:int[][]) =
  let total = (1 <<< 10) - 1
  let jkNum = 10-1
  (-System.Int32.MinValue, [|0..total|])
  ||> Array.fold (fun acc n ->
    let (c, Ca) =
      ((0, Array.zeroCreate N), [|0..jkNum|])
      ||> Array.fold (fun (c, Ca) jk ->
        let bit = n >>> jk &&& 1
        (c+bit, if bit=0 then Ca else Ca |> Array.mapi (fun i t -> t+Fa.[i].[jk])))
    if c=0 then acc
    else let p = (0, [|0..N-1|]) ||> Array.fold (fun acc jk -> acc + Pa.[jk].[Ca.[jk]]) in max acc p)

let N = stdin.ReadLine() |> int
let Fa = Array.init N (fun _ -> stdin.ReadLine().Split() |> Array.map int)
let Pa = Array.init N (fun _ -> stdin.ReadLine().Split() |> Array.map int)
solve N Fa Pa |> stdout.WriteLine

solve 1 [|[|1;1;0;1;0;0;0;1;0;1|]|] [|[|3;4;5;6;7;8;9;-2;-3;4;-2|]|] |> should equal 8
solve 2 [|[|1;1;1;1;1;0;0;0;0;0|];[|0;0;0;0;0;1;1;1;1;1|]|] [|[|0;-2;-2;-2;-2;-2;-1;-1;-1;-1;-1|];[|0;-2;-2;-2;-2;-2;-1;-1;-1;-1;-1|]|] |> should equal -2
solve 3 [|[|1;1;1;1;1;1;0;0;1;1|];[|0;1;0;1;1;1;1;0;1;0|];[|1;0;1;1;0;1;0;1;0;1|]|] [|[|-8;6;-2;-8;-8;4;8;7;-6;2;2|];[|-9;2;0;1;7;-5;0;-2;-6;5;5|];[|6;-6;7;-9;6;-5;8;0;-9;-7;-7|]|] |> should equal 23

let bitTest =
  let n = 5
  let Ni = 1 <<< n - 1
  let Nj = n - 1
  [| for i in 0..Ni do for j in 0..Nj do (i, j, i>>>j, i>>>j &&& 1)|] |> Array.iter (printfn "%A")
