#r "nuget: FsUnit"
open FsUnit

module BinarySearch1 =
  /// cf. ../../AOJ/ALDS1/04A_fs_00.fsx
  /// xa: ソート済みの配列, n: xaの要素数, x: xa中で探したい要素
  let bsearch n x xa =
    let rec search l r =
      if r<=l then false
      else
        let m = (l+r)/2
        if Array.get xa m = x then true
        elif Array.get xa m < x then search (m+1) r
        else search l m
    search 0 n

module BinarySearch2 =
  /// https://atcoder.jp/contests/abc077/submissions/17595037
  /// 適合条件を関数で指定する
  let rec bsearch l r p =
    let m = (l+r)/2
    if r<=l then l
    elif p m then bsearch m r p
    else bsearch l (m-1) p
