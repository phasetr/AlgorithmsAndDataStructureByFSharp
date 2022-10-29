#r "nuget: FsUnit"
open FsUnit

let N,Sa = 3,[|"ABCA";"XBAZ";"BAD"|]
let solve N (Sa:string[]) =
  let rec count acc = function
    | [] -> acc
    | 'A'::'B'::xs -> count (acc+1) xs
    | c::xs -> count acc xs
  let n0 = (0,Sa) ||> Array.fold (fun acc s -> acc + (s |> Seq.toList |> count 0))
  let n1 = Sa |> Array.filter (fun s -> s.StartsWith("B") && s.EndsWith("A")) |> Array.length
  let n2 = Sa |> Array.filter (fun s -> s.StartsWith("B") && not (s.EndsWith("A"))) |> Array.length
  let n3 = Sa |> Array.filter (fun s -> not (s.StartsWith("B")) && s.EndsWith("A")) |> Array.length
  if n1=0 then n0+min n2 n3
  else if n2+n3=0 then n0+n1-1 else n0+n1+min n2 n3

let N = stdin.ReadLine() |> int
let Sa = [| for i in 1..N do stdin.ReadLine() |]
solve N Sa |> stdout.WriteLine

solve 3 [|"ABCA";"XBAZ";"BAD"|] |> should equal 2
solve 9 [|"BEWPVCRWH";"ZZNQYIJX";"BAVREA";"PA";"HJMYITEOX";"BCJHMRMNK";"BP";"QVFABZ";"PRGKSPUNA"|] |> should equal 4
solve 7 [|"RABYBBE";"JOZ";"BMHQUVA";"BPA";"ISU";"MCMABAOBHZ";"SZMEHMA"|] |> should equal 4
