@"https://atcoder.jp/contests/abc103/tasks/abc103_c"
#r "nuget: FsUnit"
open FsUnit

@"任意の自然数aに対して n%a の最大値は a-1 で,
この和を取ればいい.
特に m = \prod_{i=1}^N a_i とすれば m%a_i = 0 で,
(m-1)%a_i = (N*a_i - 1) % a_i = a_i - 1 (具体例でチェックしよう)
だから実際にこの条件をみたす自然数が存在する.
一般にこの自然数は巨大で計算機で計算するのは大変だから,
直接 mod だけ計算すればよい."
let solve N As = As |> Array.fold (fun acc a -> acc + a - 1) 0
let N = stdin.ReadLine() |> int
let As = stdin.ReadLine().Split() |> Array.map int
solve N As |> stdout.WriteLine

solve 3 [|3;4;6|] |> should equal 10
solve 5 [|7;46;11;20;11|] |> should equal 90
solve 7 [|994;518;941;851;647;2;581|] |> should equal 4527
