(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_6_D/review/2427983/r6eve/OCaml *)
let quick_sort a n cmp =
  let swap i j = let tmp = a.(i) in a.(i) <- a.(j); a.(j) <- tmp in
  let partition p r =
    let i = ref p in
    for j = p to r - 1 do
      if cmp a.(j) a.(r) <= 0 then (swap !i j; incr i)
    done;
    swap !i r;
    !i in
  let rec doit p r =
    if p >= r then () else
      let q = partition p r in
      doit p (q - 1);
      doit (q + 1) r in
  doit 0 (n - 1)

let calc_cost a n =
  let b = Array.copy a in
  quick_sort b n compare;
  let t = Array.make (b.(n-1) + 1) 0 in
  Array.iteri (fun i e -> t.(e) <- i) b;
  let p = Array.make n false in
  let rec duduwa i acc =
    p.(i) <- true;
    if p.(t.(a.(i))) then a.(i) :: acc
    else duduwa t.(a.(i)) (a.(i) :: acc) in
  let rec doit i acc =
    if i = n then acc
    else if p.(i) then doit (i + 1) acc
    else
      let ws = duduwa i [] in
      let m = List.length ws in
      let s = List.fold_left (+) 0 ws in
      let z = List.fold_left min max_int ws in
      doit (i + 1) (acc + (min (s + (m - 2)*z) (s + z + (m + 1)*b.(0)))) in
  doit 0 0

let () =
  let n = read_int () in
  let a = Array.init n (fun _ -> Scanf.scanf "%d " (fun e -> e)) in
  calc_cost a n |> Printf.printf "%d\n"
