@"https://atcoder.jp/contests/agc006/tasks/agc006_a
1≤N≤100
s, t は長さ N である。
s, t は英小文字のみからなる。"
#r "nuget: FsUnit"
open FsUnit

let N,s,t = 3,"abc","cde"
@"できる文字列の長さは最長で2N.
それ以外はsの後方とtの前方に一致があればその分文字列が短くなる."
@"main=do
 n<-readLn
 s<-getLine
 t<-getLine
 let x=last[i|i<-[0..n],(drop(n-i)s)==take i t]
 print$2*n-x"
let solve N s t =
    let skipstr i = Seq.skip (N-i) s |> Seq.map string |> String.concat ""
    let takestr i = Seq.take i t |> Seq.map string |> String.concat ""
    let chk i = skipstr i = takestr i
    [|0..N|]
    |> Array.choose (fun i -> if chk i then Some i else None)
    |> Array.last
    |> fun x -> 2*N-x

let N = stdin.ReadLine() |> int
let s = stdin.ReadLine()
let t = stdin.ReadLine()
solve N s t |> stdout.WriteLine

solve 3 "abc" "cde" |> should equal 5
solve 1 "a" "z" |> should equal 2
solve 4 "expr" "expr" |> should equal 4
