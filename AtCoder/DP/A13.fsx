@"https://atcoder.jp/contests/dp/tasks/dp_a"
#r "nuget: FsUnit"
open FsUnit

let solve N (Ha:int[]) =
    let f (c2,c1,h2,h1) h = (c1,min (c2+abs(h-h2)) (c1+abs(h-h1)),h1,h)
    Array.fold f (0,abs(Ha.[0]-Ha.[1]),Ha.[0],Ha.[1]) Ha.[2..]
    |> fun (_,c,_,_) -> c
let N = stdin.ReadLine() |> int
let Ha = stdin.ReadLine().Split() |> Array.map int
solve N Ha |> stdout.WriteLine

solve 4 [|10;30;40;20|] |> should equal 30
solve 2 [|10;10|] |> should equal 0
solve 6 [|30;10;60;10;60;50|] |> should equal 40
