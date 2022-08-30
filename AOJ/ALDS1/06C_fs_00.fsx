#r "nuget: FsUnit"
open FsUnit

"""
let () =
  let n = scanf "%d\n" id in
  let ar = Array.init n (fun _ -> scanf "%s %d\n" (fun x y -> {suit = x; value = y})) in
  let ar2 = Array.copy ar in
  qsort (fun x y -> compare x.value y.value) ar 0 (n-1);
  Array.stable_sort (fun x y -> compare x.value y.value) ar2;
  printf "%s\n" (if ar = ar2 then "Stable" else "Not stable");
  Array.iter (fun x -> printf "%s %d\n" x.suit x.value) ar
"""

let solve N (Aa: (string*int)[]) =
  let swap i j = let t = Aa.[i] in Aa.[i] <- Aa.[j]; Aa.[j] <- t
  let partition cmp (a: (string*int)[]) p r =
    let x = a.[r]
    let rec frec i j =
      if j = r then swap (i+1) r; i+1
      else if cmp a.[j] x <= 0 then let ii = i+1 in  swap ii j; frec ii (j+1)
      else frec i (j+1)
    frec (p-1) p
  let rec qsort cmp a p r =
    if p >= r then ()
    else let q = partition cmp a p r in qsort cmp a p (q-1); qsort cmp a (q+1) r

  let Ba = Array.copy Aa
  qsort (fun x y -> compare (snd x) (snd y)) Aa 0 (N-1)
  let Ca = Array.sortBy (snd) Ba
  ((if Aa = Ba then "Stable" else "Not stable"), Aa |> Array.map (fun x -> sprintf "%s %d" (fst x) (snd x)))

let N = stdin.ReadLine() |> int
let Aa = [| for i in 1..N do (stdin.ReadLine().Split() |> fun x -> x.[0], int x.[1]) |]
solve N Aa |> (fun x -> stdout.WriteLine (fst x); snd x |> String.concat "\n" |> stdout.WriteLine)

solve 6 [|("D",3);("H",2);("D",1);("S",3);("D",2);("C",1)|] |> should equal ("Not stable", [|"D 1";"C 1";"D 2";"H 2";"D 3";"S 3"|])
solve 2 [|("S",1);("H",1)|] |> should equal ("Stable",[|"S 1";"H 1"|])
