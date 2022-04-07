@"https://atcoder.jp/contests/caddi2018/tasks/caddi2018_a"
#r "nuget: FsUnit"
open FsUnit

@"以下のコードはTLE"
@"Pを因数分解して因数をN個に分配する.
各最大数の積を取ればよい."
let rec getFactors n proposed (acc:list<int64>) =
    if n<=0L then failwith "be positive"
    elif n=1L then [1L]
    elif proposed = n then proposed::acc
    elif n % proposed = 0L then getFactors (n/proposed) proposed (proposed::acc)
    else getFactors n (proposed+1L) acc
let primeFactor n = getFactors n 2L []
let solve N P =
    primeFactor P |> List.countBy id
    |> List.choose (fun (p,n) ->
        let divnum = (int64 n)/N
        if divnum=0L then None else Some (p, int divnum))
    |> List.fold (fun acc (p,n) -> acc * ((pown p n) |> int64)) 1L
let N,P = stdin.ReadLine().Split() |> Array.map int64 |> (fun x -> x.[0], x.[1])
solve N P |> stdout.WriteLine

solve 3L 24L |> should equal 2L
solve 5L 1L |> should equal 1L
solve 1L 111L |> should equal 111L
solve 4L 972439611840L |> should equal 206L
