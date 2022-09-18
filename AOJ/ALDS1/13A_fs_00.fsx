#r "nuget: FsUnit"
open FsUnit

let solve N Aa =
  let rec setQueen i j Aa =
    if i=8 then Aa
    else
      if List.exists (fun a -> i = fst a) Aa then setQueen (i+1) 0 Aa
      else
        if j=8 then let (i0,j0) = List.head Aa in setQueen i0 (j0+1) (List.tail Aa)
        else if List.exists (fun a -> j = snd a) Aa ||
                  List.exists (fun (x,y) -> x+y=i+j) Aa ||
                    List.exists (fun (x,y) -> x-y=i-j) Aa then setQueen i (j+1) Aa
        else setQueen (i+1) 0 ((i,j) :: Aa)
  (Array.create 8 "........", setQueen 0 0 Aa)
  ||> List.fold
    (fun bd (r,c) -> Array.set bd r (String.mapi (fun i x -> if i=c then 'Q' else x) bd.[r]); bd)

let N = stdin.ReadLine() |> int
let Aa = [ for i in 1..N do (stdin.ReadLine().Split() |> Array.map int) ]
solve N Aa |> Array.map string |> String.concat "\n" |> stdout.WriteLine

let N,Aa = 2,[(2,2);(5,3)]
solve N Aa |> should equal [|"......Q.";"Q.......";"..Q.....";".......Q";".....Q..";"...Q....";".Q......";"....Q..."|]
