#r "nuget: FsUnit"
open FsUnit

System.IO.Directory.SetCurrentDirectory __SOURCE_DIRECTORY__

let solve N Sa =
  let mutable counter = 0
  let merge (array:int[]) left mid right =
    let init n p = Array.init (n+1) (fun i -> if i=n then System.Int32.MaxValue else array.[p+i])
    let xs = init (mid-left) left
    let ys = init (right-mid) mid
    let rec loop i j k =
      if k < right then
        counter <- counter+1
        if xs.[i] <= ys.[j] then (array.[k] <- xs.[i]; loop (i+1) j (k+1))
        else array.[k] <- ys.[j]; loop i (j+1) (k+1)
    in loop 0 0 left
  let rec msort array left right =
    if left+1 < right then
      let mid = (left+right)/2
      msort array left mid
      msort array mid right
      merge array left mid right
  msort Sa 0 N; (counter, Sa)

let N = stdin.ReadLine() |> int
let Sa = stdin.ReadLine().Split() |> Array.map int
solve N Sa |> (fun x -> fst x |> std.WriteLine; snd x |> std.WriteLine)

solve 10 [|8;5;9;2;6;3;7;1;10;4|] |> should equal (34, [|1..10|])
