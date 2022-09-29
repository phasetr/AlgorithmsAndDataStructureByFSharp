#r "nuget: FsUnit"
open FsUnit

let solve (h,w) (r,c) Aa Ba =
  let (p1, p2, p3) = (257, 251, 1000000007)
  let pow x n =
    let rec doit x n acc =
      if n = 0 then acc
      else if n%2 = 0 then doit (x*x%p3) (n/2) acc
      else doit (x*x%p3) (n/2) (acc*x%p3)
    doit x n 1

  let make_hash (v: char[][]) (x,y) (r,c) =
    let mutable h1 = Array2D.create x y 0
    let c1 = pow p1 c
    for i = 0 to x-1 do
      let rec aux j acc = if j=c then acc else aux (j+1) ((acc*p1 + int v.[i].[j])%p3)
      let rec doit j z =
        if j=y-c then h1.[i,j] <- z
        else
          h1.[i,j] <- z
          let z = (z*p1 - (int v.[i].[j])*c1 + int v.[i].[j+c])%p3
          doit (j+1) (if z<0 then z+p3 else z)
      aux 0 0 |> doit 0;
    done
    let mutable h2 = Array2D.create x y 0
    let c2 = pow p2 r
    for j=0 to y-1 do
      let rec aux i acc = if i=r then acc else aux (i+1) ((acc*p2 + h1.[i,j])%p3)
      let rec doit i z =
        if i=x-r then h2.[i,j] <- z
        else
          h2.[i,j] <- z;
          let z = (z*p2 - h1.[i,j]*c2 + h1.[i+r,j])%p3
          doit (i+1) (if z<0 then z+p3 else z)
      aux 0 0 |> doit 0;
    done
    h2

  let s = make_hash Aa (H,W) (R,C)
  let t = make_hash Ba (R,C) (R,C)
  [| for i in 0..H-R do for j in 0..W-C do if s.[i,j]=t.[0,0] then yield [|i;j|] |]

let H,W = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0],x.[1])
let Aa = [| for i in 1..H do (stdin.ReadLine() |> Array.ofSeq) |]
let R,C = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0],x.[1])
let Ba = [| for i in 1..R do (stdin.ReadLine() |> Array.ofSeq) |]
solve (H,W) (R,C) Aa Ba |> Array.iter (Array.map string >> String.concat " " >> stdout.WriteLine)

let (H,W) = 4,5
let Aa = [|[|'0';'0';'0';'1';'0'|];[|'0';'0';'1';'0';'1'|];[|'0';'0';'0';'1';'0'|];[|'0';'0';'1';'0';'0'|]|]
let (R,C) = 3,2
let Ba = [|[|'1';'0'|];[|'0';'1'|];[|'1';'0'|]|]
solve (H,W) (R,C) Aa Ba |> should equal [|[|0;3|];[|1;2|]|]
