@"https://atcoder.jp/contests/abc109/tasks/abc109_c"
#r "nuget: FsUnit"
open FsUnit

@"Xと座標間の差を取った最小値がだいたいのイメージ.
細かい部分やエッジケースをどう攻めるか?
Dが全てのiに対して|X-x_i|の約数ならよく,
特に最小公倍数を取ればよい."
let N,X,Xs = 3L,3L,[|1L;7L;11L|]
let solve N X Xs =
    let gcd: int64 -> int64 -> int64 = fun x y ->
        let rec locgcd x y =
            match y with
            | 0L -> x
            | _ -> locgcd y (x % y)
        if x >= y then locgcd x y else locgcd y x

    Xs |> Array.map (fun x -> abs (x-X))
    |> Array.reduce (fun acc x -> gcd acc x)

let N, X = stdin.ReadLine().Split() |> Array.map int64 |> (fun x -> x.[0], x.[1])
let Xs = stdin.ReadLine().Split() |> Array.map int64
solve N X Xs |> stdout.WriteLine

solve 3L 3L [|1L;7L;11L|] |> should equal 2L
solve 3L 81L [|33L;105L;57L|] |> should equal 24L
solve 1L 1L [|1000000000L|] |> should equal 999999999L
