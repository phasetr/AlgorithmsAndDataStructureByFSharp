#r "nuget: FsUnit"
open FsUnit

// let N,X = 2,7L
// let N,X = 1,5L
let solve N X =
  let Ba = (1L,[|0..50|]) ||> Array.scan (fun acc _ -> 2L*acc+3L)
  let Pa = (1L,[|0..50|]) ||> Array.scan (fun acc _ -> 2L*acc+1L)

  let rec frec acc n x =
    // 計算がまわり切った
    if x<=0L then acc
    // レベルnバーガーの下n枚はバンズ
    elif x<=(int64 n) then acc
    // レベルnバーガーの上n枚はバンズ
    elif Ba.[n]-x <= n then acc + Pa.[n]
    // 下のレベルn-1バーガーの中に納まる
    elif (x-1L)<=Ba.[n-1] then frec acc (n-1) (x-1L)
    // ちょうど真ん中のパティまで
    elif (x-1L - Ba.[n-1] - 1L) = 0L then acc + Pa.[n-1] + 1L
    // 残り
    else frec (acc + Pa.[n-1] + 1L) (n-1) (x-1L-Ba.[n-1]-1L)
  frec 0 N X

let N,X = stdin.ReadLine().Split() |> (fun x -> int x.[0], int64 x.[1])
solve N X |> stdout.WriteLine

let rec burger N acc = if N<=0 then acc else burger (N-1) ("B"+acc+"P"+acc+"B")
burger 0 "P" |> should equal "P"
burger 1 "P" |> should equal "BPPPB"
burger 2 "P" |> should equal "BBPPPBPBPPPBB"

solve 2 7L |> should equal 4L
solve 1 1L |> should equal 0L
solve 50 4321098765432109L |> should equal 2160549382716056L

solve 1 5L |> should equal 3L
