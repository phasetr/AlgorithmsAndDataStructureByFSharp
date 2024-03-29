#r "nuget: FsUnit"
open FsUnit

"cf.https://atcoder.jp/contests/dp/submissions/20822591"
let N,Aa = 3,[|(1,2);(2,3)|]
let solve N Aa =
    let m = 1_000_000_007L
    let (.+) x y = (x+y)%m
    let (.*) x y = (x*y)%m

    let memoize3 dimx dimy f =
        let memo = Array2D.create dimx dimy None
        let rec g n m o =
            match memo.[n,m] with
                | Some x -> x
                | None ->
                    let result = f g n m o
                    Array2D.set memo n m (Some result)
                    result
        g

    let g =
        (Array.create N [], Aa)
        ||> Array.fold (fun g (x,y) ->
            Array.set g (x-1) ((y-1)::g.[x-1])
            Array.set g (y-1) ((x-1)::g.[y-1])
            g)
    let f frec v vColor parent =
        g.[v]
        |> List.choose (fun nv ->
            if nv=parent then None
            else if vColor=0 then Some (frec nv 0 v .+ frec nv 1 v) else Some (frec nv 0 v))
        |> List.fold (.*) 1L
    let dfs = memoize3 N 2 f
    dfs 0 0 0 .+ dfs 0 1 0
let N = stdin.ReadLine() |> int
let Aa = [| for i in 1..N-1 do (stdin.ReadLine().Split() |> Array.map int |> fun x -> x.[0],x.[1]) |]
solve N Aa |> stdout.WriteLine

solve 3 [|(1,2);(2,3)|] |> should equal 5L
solve 4 [|(1,2);(1,3);(1,4)|] |> should equal 9L
solve 1 [||] |> should equal 2L
solve 10 [|(8,5);(10,8);(6,5);(1,5);(4,8);(2,10);(3,6);(9,2);(1,7)|] |> should equal 157L
