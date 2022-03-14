@"https://atcoder.jp/contests/abc047/tasks/abc047_b
- 1 ≦ W, H ≦ 100
- 1 ≦ N ≦ 100
- 0 ≦ x_i ≦ W (1 ≦ i ≦ N)
- 0 ≦ y_i ≦ H (1 ≦ i ≦ N)
- W, H (21:32 追記), x_i, y_i は整数である
- a_i (1 ≦ i ≦ N) は 1, 2, 3, 4 のいずれかである"
#r "nuget: FsUnit"
open FsUnit

@"領域の左右上下をfoldで回せばよい."
let solve W H N Da =
    ((H,0,0,W), Da) ||> Array.fold (fun (u,d,l,r) (x,y,a) ->
        if a=1 then (u, d, max l x, r)
        elif a=2 then (u, d, l, min r x)
        elif a=3 then (u, max d y, l, r)
        else (min u y, d, l, r))
    |> fun (u,d,l,r) -> if l <= r && d <= u then (u-d)*(r-l) else 0
let W,H,N = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0], x.[1], x.[2])
let Da = [| for i in 1..N do (stdin.ReadLine().Split() |> Array.map int) |> (fun x -> x.[0], x.[1], x.[2]) |]
solve W H N Da |> stdout.WriteLine

solve 5 4 2 [|(2,1,1);(3,3,4)|] |> should equal 9
solve 5 4 3 [|(2,1,1);(3,3,4);(1,4,2)|] |> should equal 0
solve 10 10 5 [|(1,6,1);(4,1,3);(6,9,4);(9,4,2);(3,1,3)|] |> should equal 64
