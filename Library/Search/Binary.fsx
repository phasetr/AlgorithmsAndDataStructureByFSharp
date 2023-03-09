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
        let xam = Array.get xa m
        if xam = x then true
        elif xam < x then search (m+1) r
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

module BinarySearch3 =
  /// ../../AtCoder/tessoku-book/A11/A11_fs_00_01.fsx
  let Ia = [|11;13;17;19;23;29;31;37;41;43;47;53;59;61;67|]
  let N = Ia |> Array.length
  let rec bsearch l r X =
    let m = (l+r)/2
    if r<l then None
    elif Ia.[m]=X then Some m
    elif X<Ia.[m] then bsearch l (m-1) X
    else bsearch (m+1) r X
  bsearch 0 (N-1) 47 |> should equal (Some 10)

module BinarySearch4 =
  /// ../../AtCoder/tessoku-book/A11/A15_fs_00_01.fsx
  let Ia = [|11;13;17;19;23;29;31;37;41;43;47;53;59;61;67|]
  let rec bsearch x (Xa:int[]) =
    let mutable l,r = 0,Xa.Length
    while 1<r-l do let m = (l+r)/2 in if x<Xa.[m] then r<-m-1 else l<-m+1
    r
  Ia |> bsearch 47 |> should equal 10

  let Ia = [|11;13;17;19;23;29;31;37;41;43;47;53;59;61;67|]
  let rec bsearch x (Xa:int[]) =
    let mutable l,r = 0,Xa.Length
    while 1<r-l do let m = (l+r)/2 in if x<=Xa.[m] then r<-m else l<-m
    r
  Ia |> bsearch 47 |> should equal 10
