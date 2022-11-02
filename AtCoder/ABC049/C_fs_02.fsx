// https://atcoder.jp/contests/abc049/submissions/21133606
let s=stdin.ReadLine()
let n=s.Length
let dp:bool[]=Array.zeroCreate(n+1)

let words=["dream";"dreamer";"erase";"eraser"]

dp.[0]<-true
for i in [0..n-1] do
  if dp.[i] then words|>List.iter(fun str -> if (i+str.Length<=n&&s.Substring(i,str.Length)=str) then (dp.[i+str.Length]<-true))

if dp.[n] then "YES" else "NO"
|>printfn"%s"
