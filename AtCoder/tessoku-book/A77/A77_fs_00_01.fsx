#r "nuget: FsUnit"
open FsUnit

(*
let N,L,K,Aa = 3,34,1,[|8;13;26|]
let N,L,K,Aa = 7,45,2,[|7;11;16;20;28;34;38|]
let N,L,K,Aa = 3,100,2,[|28;54;81|]
let N,L,K,Aa = 20,1000,4,[|51;69;102;127;233;295;350;388;417;466;469;523;553;587;720;739;801;855;926;954|]
*)
let solve N L K Aa =
  let check x =
    ((0,0),Aa)
    ||> Array.fold (fun (count,i) a -> if x<= min (a-i) (L-a) then (count+1,a) else (count,i))
    |> fst |> (<=) K
  let rec bsearch l r =
    if r<=l then l
    else let m = (l+r+1)/2 in if check m then bsearch m r else bsearch l (m-1)
  bsearch 1 L

let N,L = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0],x.[1])
let K = stdin.ReadLine() |> int
let Aa = stdin.ReadLine().Split() |> Array.map int
solve N L K Aa |> stdout.WriteLine

solve 3 34 1 [|8;13;26|] |> should equal 13
solve 7 45 2 [|7;11;16;20;28;34;38|] |> should equal 12
solve 3 100 2 [|28;54;81|] |> should equal 26
solve 20 1000 4 [|51;69;102;127;233;295;350;388;417;466;469;523;553;587;720;739;801;855;926;954|] |> should equal 170
