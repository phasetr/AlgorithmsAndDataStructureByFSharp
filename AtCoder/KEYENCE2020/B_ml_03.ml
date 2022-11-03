(* https://atcoder.jp/contests/keyence2020/submissions/9569521 *)
let rec upper_bound l r p =
  if r <= 1 + l
  then l
  else let m = (l + r) / 2 in
       if p m
       then upper_bound m r p
       else upper_bound l m p

let () =
  Scanf.scanf "%d\n" @@
    fun n ->
    let xls = Array.init (n + 1) @@ function
                                   | 0 -> (-100000000, 0)
                                   | _ -> Scanf.scanf "%d %d\n" @@ fun x l -> x, l in
    Array.sort (fun (x, l) (x', l') -> compare (x + l) (x' + l')) xls;
    let dp = Array.make (n + 1) 0 in
    for i = 1 to n do
      dp.(i) <- max (dp.(i - 1)) @@
                  1 + dp.(upper_bound 0 i (fun j ->
                              fst (xls.(j)) + snd (xls.(j)) <= fst (xls.(i)) - snd (xls.(i))))
    done;
    Printf.printf "%d\n" dp.(n)
