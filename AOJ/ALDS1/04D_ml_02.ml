(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_4_D/review/2106478/centillioncolors/OCaml *)
let () =
  let (n,k) = Scanf.scanf "%d %d\n" (fun x y->(x,y)) in
  let a = Array.init n (fun _ -> Scanf.scanf "%d\n" (fun x->x)) in
  let l = Array.fold_left (fun x y -> max x y) 0 a and
      r = 100000*100000 in
  let rec load ((i,j,s,p):int*int*int*int):bool =
    if i=n then true
    else if j=k then false
    else if s+a.(i) <= p then load ((i+1), j, (s+a.(i)), p) else load (i,(j+1),0,p)
  in
  let rec loop (left:int) (right:int):int =
    if left < right then
      let mid = (left+right)/2 in
      if load (0,0,0,mid) then loop left mid
      else loop (mid+1) right
    else right
  in Printf.printf "%d\n" (loop l r)
