#r "nuget: FsUnit"
open FsUnit

// ../../AOJ/ALDS1/06A_fs_00.fsx
module Counting1 =
  let csort n (a: int[]) =
    let k = Array.max a
    let b = Array.create N 0
    let len = n-1
    let c = Array.create (k+1) 0
    Array.iter (fun x -> c.[x] <- c.[x]+1) a;
    for i = 1 to k do
      c.[i] <- c.[i] + c.[i-1]
    done
    for i = len downto 0 do
      let j = len - i in
      b.[c.[a.[j]]-1] <- a.[j]; c.[a.[j]] <- c.[a.[j]]-1
    done
    b
  csort 7 [|2;5;1;3;2;3;0|] |> should equal [|0;1;2;2;3;3;5|]
