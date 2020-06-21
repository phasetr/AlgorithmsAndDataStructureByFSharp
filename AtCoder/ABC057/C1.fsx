(*
https://atcoder.jp/contests/abc057/tasks/abc057_c
cf. https://atcoder.jp/contests/abc057/submissions/14083685
巨大な素数で時間がかかりすぎて TLE：リスト生成が問題
*)
let maxDivisorDigit n =
  seq { for i in [1L..n] do if n % i = 0L && n <= i * i then i }
  |> Seq.reduce min
  |> (string >> Seq.length)
  |> printfn "%d"

for n in [| 10000L; 1000003L; 9876543210L |] do
  maxDivisorDigit n