@"https://atcoder.jp/contests/abc079/tasks/abc079_c"
#r "nuget: FsUnit"
open FsUnit

[1
 2147483647
 3]
let ys = [|
          1
          2
          |]

let solve Xs =
    let xs = Xs |> Seq.map (string >> int) |> Seq.toArray
    let (x1,x2,x3,x4) = xs.[0],xs.[1],xs.[2],xs.[3]
    let (s1,s2,s3,s4) = Array.map string xs |> fun ss -> ss.[0],ss.[1],ss.[2],ss.[3]
    [|
     (x1+x2+x3+x4, s1 + "+" + s2 + "+" + s3 + "+" + s4)
     (x1-x2+x3+x4, s1 + "-" + s2 + "+" + s3 + "+" + s4)
     (x1+x2-x3+x4, s1 + "+" + s2 + "-" + s3 + "+" + s4)
     (x1+x2+x3-x4, s1 + "+" + s2 + "+" + s3 + "-" + s4)
     (x1-x2-x3+x4, s1 + "-" + s2 + "-" + s3 + "+" + s4)
     (x1-x2+x3-x4, s1 + "-" + s2 + "+" + s3 + "-" + s4)
     (x1+x2-x3-x4, s1 + "+" + s2 + "-" + s3 + "-" + s4)
     (x1-x2-x3-x4, s1 + "-" + s2 + "-" + s3 + "-" + s4)|]
    |> Array.filter (fun (s,_) -> s = 7)
    |> Array.head
    |> fun (_,s) -> s + "=7"

let Xs = stdin.ReadLine()
solve Xs |> stdout.WriteLine

solve "1222" |> should equal "1+2+2+2=7"
solve "0290" |> should equal "0-2+9+0=7"
solve "3242" |> should equal "3+2+4-2=7"
