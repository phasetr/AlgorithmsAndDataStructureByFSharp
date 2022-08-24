#r "nuget: FsUnit"
open FsUnit

/// cf. ../../AOJ/ALDS1/04A_fs_00.fsx
/// xa: ソート済みの配列, n: xaの要素数, x: xa中で探したい要素
let bsearch xa n x =
  let rec search l r =
    if r<=l then false else
      let m = (l+r)/2
      if Array.get xa m = x then true
      else if Array.get xa m < x then search (m+1) r
      else search l m
  search 0 n
