#r "nuget: FsUnit"
open FsUnit

let solve Xa =
  let mutable iref = 0
  let parent i = i/2
  let left i = 2*i
  let right i = 2*i+1

  let extract (t: int array) =
    let swap i j = let ti = t.[i] in t.[i] <- t.[j]; t.[j] <- ti
    let rec maxHeapify i =
      let l = left i
      let r = right i
      let m = if l <= iref && t.[i] < t.[l] then l else i
      let m = if r <= iref && t.[m] < t.[r] then r else m
      if i <> m then swap i m; maxHeapify m
    let ret = t.[1]
    t.[1] <- t.[iref]
    iref <- iref-1
    maxHeapify 1
    ret

  let insert x (t: int array) =
    let swap i j = let ti = t.[i] in t.[i] <- t.[j]; t.[j] <- ti
    let rec frec i =
      let p = parent i
      if i <= 1 || t.[i] <= t.[p] then () else swap i p; frec p
    iref <- iref + 1
    t.[iref] <- x
    frec iref

  let mutable t = Array.create (Array.length Xa) 0
  Xa
  |> Array.iter
    (function
     | [|"extract"|] -> extract t |> stdout.WriteLine
     | [|"insert";n|] -> insert (int n) t
     | _ -> ())
  t

let Xa = [| for i in 1..N do (stdin.ReadLine().Split()) |]
solve Xa

let Xa = [|[|"insert";"8"|];[|"insert";"2"|];[|"extract"|];[|"insert";"10"|];[|"extract"|];[|"insert";"11"|];[|"extract"|];[|"extract"|];[|"end"|]|]
solve Xa
"""
8
10
11
2
"""
