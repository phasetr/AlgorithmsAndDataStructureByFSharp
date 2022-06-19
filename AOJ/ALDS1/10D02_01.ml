(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_10_D/review/5636530/que0/OCaml *)
let n = read_int ()
let k = Array.init n (fun _ -> Scanf.scanf "%f " (fun x -> x))
let d = Array.init (n + 1) (fun _ -> Scanf.scanf "%f " (fun x -> x))

let memo = Array.make_matrix 500 500 ~-.9.9
let memo2 = Array.make_matrix 500 500 ~-.9.9
let asum a ab ae =
  let s = ref 0.0 in (for i = ab to ae do s := !s +. a.(i) done; !s)

let kdsum k d kb ke =
  if memo2.(kb).(ke) >= 0.
  then memo2.(kb).(ke)
  else let s = (asum k kb ke) +. (asum d kb (ke + 1)) in (memo2.(kb).(ke) <- s; s )

let rec min_cost1 k d kb ke kt =
  if kb = ke then ((d.(kb) +. d.(kb+1)))
  else if ke = kt then d.(kt + 1) +. (min_cost k d kb (ke - 1))
  else if kb = kt then d.(kt) +. (min_cost k d (kb + 1) ke)
  else (min_cost k d kb (kt - 1)) +. (min_cost k d (kt + 1) ke)
and min_cost k d kb ke =
  if memo.(kb).(ke) >= 0.
  then memo.(kb).(ke)
  else
    let m = ref 9.9 in (
        for kt = kb to ke do
          let c1 = min_cost1 k d kb ke kt in
          let c2 = kdsum k d kb ke in
          m := min !m (c1 +. c2)
        done;
        memo.(kb).(ke) <- !m;
        !m);;
print_float @@ min_cost k d 0 (n-1);;
print_newline ()
