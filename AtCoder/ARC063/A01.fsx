@"https://atcoder.jp/contests/abc047/tasks/arc063_a
* 1 ≦ |S| ≦ 10^5
* S に含まれる文字は B または W のいずれかである"
#r "nuget: FsUnit"
open FsUnit

@"左からtakeWhileで攻めていけばよいか?
連続している部分は一文字に潰してよい.

解説から: 色が連続する区間を一つに潰して区間数を数え,
その数から1を引けばよい."
let solve S =
    let rec groupBy eq = function
        | [] -> []
        | x::xs ->
            let (ys,zs) = (List.takeWhile (eq x) xs, List.skipWhile (eq x) xs)
            (x::ys) :: groupBy eq zs
    groupBy (=) (S |> Seq.toList) |> fun s -> (List.length s) - 1
let S = stdin.ReadLine()
solve S |> stdout.WriteLine

solve "BBBWW" |> should equal 1
solve "WWWWWW" |> should equal 0
solve "WBWBWBWBWB" |> should equal 9
