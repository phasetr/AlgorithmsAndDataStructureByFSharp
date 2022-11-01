(* https://atcoder.jp/contests/abc113/submissions/3543474 *)
Scanf.scanf "%d %d" (fun n m ->
  let vs = Array.init m (fun i ->
    Scanf.scanf " %d %d" (fun p y->(y,p,i))
  ) in
  Array.sort compare vs;
  let qs = Array.make m "" in
  let ns = Array.make n 0 in
  Array.iter (fun (y,p,i) ->
    let n = ns.(p-1)+1 in
    ns.(p-1)<-n;
    qs.(i)<-Printf.sprintf "%06d%06d\n" p n
  ) vs;
  Array.iter (Printf.printf "%s") qs
)
