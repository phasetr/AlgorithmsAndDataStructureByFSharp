(*
https://atcoder.jp/contests/abc169/tasks/abc169_d
*)

/// Seq に対する head-tail の分解
/// Active Pattern 利用
let (|SeqEmpty|SeqCons|) (xs: 'a seq) =
    if Seq.isEmpty xs then SeqEmpty else SeqCons(Seq.head xs, Seq.skip 1 xs)

/// group: Haskell の group と同じ
/// http://hackage.haskell.org/package/base-4.14.0.0/docs/Data-List.html#v:group
/// group "Mississippi"
/// seq [seq ['M']; seq ['i']; seq ['s'; 's']; seq ['i']; ...]
let rec group =
    function
    | SeqEmpty -> Seq.empty
    | SeqCons (x, xs) ->
        let ys: 'a seq = Seq.takeWhile ((=) x) xs
        let zs: 'a seq = Seq.skipWhile ((=) x) xs
        Seq.append (seq { Seq.append (seq { x }) ys }) (group zs)
