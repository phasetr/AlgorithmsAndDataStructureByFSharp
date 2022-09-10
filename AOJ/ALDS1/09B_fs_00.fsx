#r "nuget: FsUnit"
open FsUnit

let solve N Xa =
  let parent i = ((float i) / 2.0) |> floor |> int
  let left i = 2*i
  let right i = 2*i + 1
  let t = [|0..N|] |> Array.map (fun i -> if i=0 then 0 else Array.get Xa (i-1))

  let buildMaxHeapify (t: int array) h =
    let swap i j = let x = t.[i] in t.[i] <- t.[j]; t.[j] <- x
    let rec maxHeapify i =
      let l = left i
      let r = right i
      let m = if l <= h && t.[l] > t.[i] then l else i
      let m = if r <= h && t.[r] > t.[m] then r else m
      if i = m then () else swap i m; maxHeapify m
    for i = parent h downto 1 do
      maxHeapify i
    done
    t

  buildMaxHeapify t N |> fun x -> x.[1..]

let N = stdin.ReadLine() |> int
let Xa = stdin.ReadLine().Split() |> Array.map int
solve N Xa |> Array.map string |> String.concat " " |> stdout.WriteLine

let N,Xa = 10,[|4;1;3;2;16;9;10;14;8;7|]
solve N Xa |> should equal [|16;14;10;8;7;9;3;2;4;1|]
