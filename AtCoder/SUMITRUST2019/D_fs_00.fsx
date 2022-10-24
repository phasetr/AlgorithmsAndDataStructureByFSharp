#r "nuget: FsUnit"
open FsUnit

let N,S = 4,"0224"
let solve N (S:string) =
  let s = S |> Seq.map (fun x -> int x - int '0') |> Array.ofSeq
  let search num pstra = pstra |> Array.tryFindIndex (fun n -> num=n)
  let osearch i j k s =
    search i s
    |> Option.map (fun i0 ->
      match search j s.[i0+1..] with
        | Some j0 -> Some(i0,i0+1+j0)
        | _ -> None) |> Option.flatten
    |> Option.map (fun (i0,j0) ->
      match search k s.[j0+1..] with
        | Some k0 -> Some ([|S.[i0];S.[j0];S.[j0+1+k0]|] |> System.String)
        | _ -> None) |> Option.flatten

  let nums = [|0..9|]
  [| for i in nums do for j in nums do for k in nums -> osearch i j k s |]
  |> Array.choose id |> Array.distinct |> Array.length

let N = stdin.ReadLine() |> int
let S = stdin.ReadLine()
solve N S |> stdout.WriteLine

solve 4 "0224" |> should equal 3
solve 6 "123123" |> should equal 17
solve 19 "3141592653589793238" |> should equal 329
