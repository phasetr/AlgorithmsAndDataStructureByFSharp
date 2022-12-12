// https://atcoder.jp/contests/abc140/submissions/7485646
let (N,K) = stdin.ReadLine().Split() |> Array.map int |> fun x -> x.[0],x.[1]
let S=stdin.ReadLine()
S |> Seq.pairwise |> Seq.map (fun x->if x=('R','L') then 1 else 0) |> Seq.sum
|> fun x->
    if S.[0]='L' && S.[N-1]='R' then (x,2)
    elif S.[0]='L' || S.[N-1]='R' then (x,1)
    else (x,0)
|> fun (x,y)->
    let a=min x K
    let b=min (K-a) y
    min (N-x*2-y+a*2+b) (N-1)
|> stdout.WriteLine
