(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_6_D/review/5518859/que0/OCaml *)
let n = read_int ()
let a = Array.init n (fun _ -> Scanf.scanf "%d " (fun x -> x))
let ma = Array.fold_left min max_int a
let s = Array.mapi (fun i x -> x, i) a;;
Array.sort compare s;;
let r = Array.make n 0;;
Array.iteri (fun i (_, e) -> r.(e) <- i) s;;
let t = Array.make n 0

let get_loop r t i =
  let rec gl i ii ll =
    if ii = i
    then ll
    else (t.(i) <- 1; gl r.(i) ii (i :: ll)) in (
      t.(i) <- 1; gl r.(i) i [i] )
let c = ref 0;;
Array.iteri
  (fun i e ->
    if t.(i) = 0
    then
      let lp = List.sort (fun x y -> compare a.(x) a.(y)) (get_loop r t i) in
      let cl =
        match lp with
        | [] -> 0
        | mi :: gl ->
           let ll = List.length lp in
           let gs = List.fold_left (fun x y -> x + a.(y)) 0 gl in
           min (pred ll * a.(mi) + gs) (succ ll * ma + 2 * a.(mi) + gs) in
      c := !c + cl )
  r;
Printf.printf "%d\n" !c
