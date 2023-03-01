#r "nuget: FsUnit"
open FsUnit

(*
let N,Aa = 4,[|2;4;1;3|]
let N,Aa = 7,[|3;6;4;5;7;1;2;|]
*)
let solve N (Aa:int[]) =
  let siz =
    let mutable siz = 1
    while siz<N do siz <- siz*2
    siz
  let update p x (dat:int64[]) =
    let mutable pos = p + siz - 1
    dat.[pos] <- x
    while pos>=2 do pos<-pos/2; dat.[pos] <- dat.[2*pos] + dat.[2*pos+1]
  let rec query l r a b u (dat:int64[]) =
    if r<=a || b<=l then 0L
    elif l<=a && b<=r then dat.[u]
    else let m = (a+b)/2 in (query l r a m (2*u) dat) + (query l r m b (2*u+1) dat)

  let dat = Array.create (2*siz+1) 0L
  let mutable ans = 0L
  for i in 0..N-1 do
    ans <- ans + query (Aa.[i]+1) (N+1) 1 (1+siz) 1 dat
    update Aa.[i] 1L dat
  ans

let N = stdin.ReadLine() |> int
let Aa = stdin.ReadLine().Split() |> Array.map int
solve N Aa |> stdout.WriteLine

solve 4 [|2;4;1;3|] |> should equal 3L
solve 7 [|3;6;4;5;7;1;2;|] |> should equal 12L
