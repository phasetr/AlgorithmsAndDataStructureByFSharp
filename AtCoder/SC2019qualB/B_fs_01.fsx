// https://atcoder.jp/contests/jsc2019-qual/submissions/7123102
let reads f = stdin.ReadLine().Split(' ') |> Array.map f
let [| n; k |] = reads int64
let bs = reads int
let mutable na = 0L
let mutable nb = 0L
for i = 0 to int n-2 do
  for j = i+1 to int n-1 do
    if bs.[i] > bs.[j] then na <- na + 1L
    if bs.[i] < bs.[j] then nb <- nb + 1L

let m = int64 (10.**9.) + 7L
(k*(k-1L)/2L % m*(na+nb)%m + k*na%m) % m
|> printfn "%d"
