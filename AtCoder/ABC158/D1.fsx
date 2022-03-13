@"https://atcoder.jp/contests/abc158/tasks/abc158_d
- 1 \leq |S| \leq 10^5
- S は英小文字から成る
- 1 \leq Q \leq 2 \times 10^5
- T_i = 1 または 2
- F_i = 1 または 2
- C_i は英小文字である"
#r "nuget: FsUnit"
open FsUnit

@"各操作で反転していたら簡単にTLEになるからルールを見つける.
T_i=1の処理をどうまとめるかがポイント.
先頭に追加するべき文字列・末尾に追加するべき文字列をfoldで持ち,
T_i=1のときに反転させていけばよい."
let solve (S: string) Q Qa =
    let rev (s:string) = s |> Seq.toArray |> Array.rev |> System.String
    let str (s:list<string>) = s |> List.toArray |> String.concat ""
    ((false,[""],[""]),Qa)
    ||> Array.fold (fun (isrev,h,t) (ti,fi,ci) ->
        if ti=1 then (not isrev,t,h)
        else if fi=1 then (isrev,ci::h,t) else (isrev,h,ci::t))
    |> fun (isrev,h,t) ->
        (str h) + (if isrev then rev S else S) + (str t |> rev)
let S = stdin.ReadLine()
let Q = stdin.ReadLine() |> int
let Qa = [| for i in 1..Q do (stdin.ReadLine().Split() |> fun x -> if Array.length x = 1 then (1,0,"") else (int x.[0], int x.[1], x.[2])) |]
solve S Q Qa |> stdout.WriteLine

solve "a" 4 [|(2,1,"p");(1,0,"");(2,2,"c");(1,0,"")|] |> should equal "cpa"
solve "a" 6 [|(2,2,"a");(2,1,"b");(1,0,"");(2,2,"c");(1,0,"");(1,0,"")|] |> should equal "aabc"
solve "y" 1 [|(2,1,"x")|] |> should equal "xy"
