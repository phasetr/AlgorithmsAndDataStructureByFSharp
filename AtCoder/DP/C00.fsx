@"https://atcoder.jp/contests/dp/tasks/dp_c
明日から太郎君の夏休みが始まります。
太郎君は夏休みの計画を立てることにしました。

夏休みは N 日からなります。
各 i (1≤i≤N) について、i 日目には太郎君は次の活動のうちひとつを選んで行います。

A: 海で泳ぐ。 幸福度 ai を得る。
B: 山で虫取りをする。 幸福度 bi を得る。
C: 家で宿題をする。 幸福度 ci を得る。
太郎君は飽き性なので、2 日以上連続で同じ活動を行うことはできません。
太郎君が得る幸福度の総和の最大値を求めてください。

制約
入力はすべて整数である。
1≤N≤10^5
1≤ai,bi,ci≤10^4"
#r "nuget: FsUnit"
open FsUnit

let N,Ha = 3,[|[|10,40,70|];[|20,50,80|];[|30,60,90|]|]
let solve N Ha = 1
let N = stdin.ReadLine() |> int
let Ha = [| for i in 1..N do (stdin.ReadLine().Split() |> Array.map int) |]
solve N Ha |> stdout.WriteLine

solve 3 [|(10,40,70);(20,50,80);(30,60,90)|] |> should equal 210
solve 1 [|(100,10,1)|] |> should equal 100
solve 7 [|(6,7,8);(8,8,3);(2,5,2);(7,8,6);(4,6,8);(2,3,4);(7,5,1)|] |> should equal 46
