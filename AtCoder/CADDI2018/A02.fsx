@"https://atcoder.jp/contests/caddi2018/tasks/caddi2018_a"
#r "nuget: FsUnit"
open FsUnit

let rec f c i p =
    if p%i=0L then f (c+1L) i (p/i)
    elif c<>0L then (i,c) :: f 0L (i+1L) p
    elif p < i*i then [(p,1L)]
    else (i,c) :: f 0L (i+1L) p
let solve N P =
    f 0L 2L P
    |> List.map (fun (p,n) -> (p,n/N))
    |> List.fold (fun acc (p,n) -> acc * (pown p (int n))) 1L
let N,P = stdin.ReadLine().Split() |> Array.map int64 |> (fun x -> x.[0], x.[1])
solve N P |> stdout.WriteLine

solve 3L 24L |> should equal 2L
solve 5L 1L |> should equal 1L
solve 1L 111L |> should equal 111L
solve 4L 972439611840L |> should equal 206L
