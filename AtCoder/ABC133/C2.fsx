@"https://atcoder.jp/contests/abc133/submissions/11968764"
#r "nuget: FsUnit"
open FsUnit

let solve L R =
    let n = 2019L
    let rec frec m i j =
        if i = R then m
        elif m = 0L then m
        elif j = R+1L then frec m (i+1L) (i+2L)
        elif i*j%n < m then frec (i*j%n) i (j+1L)
        else frec m i (j+1L)
    frec n L (L+1L)

let L,R = stdin.ReadLine().Split() |> Array.map int64 |> (fun x -> x.[0], x.[1])
solve L R |> stdout.WriteLine

solve 2020L 2040L |> should equal 2L
solve 4L 5L |> should equal 20L
