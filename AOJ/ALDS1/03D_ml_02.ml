(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_3_D/review/5497634/que0/OCaml *)
open Stack
let str = read_line ()
let sec = create ();;
push (0, 0) sec;;
String.iter
  (fun c ->
    let (fa, fm) = top sec in
    let a = fa + match c with '\\' -> -1 | '_' -> 0 | '/' -> 1 |a->0 in
    push (a, max fm a) sec)
  str
;;
let stack_fold f i s =
  let a = ref i in
  (iter (fun e -> a := (f !a e)) s; !a)
;;
let ps = create();;
stack_fold
  (fun (bm, ps, fc, fa) (al, fm) ->
    let m = min fm bm in
    match (al - m, fc) with
    | (d, false) when d >= 0 -> (al, ps, false, al)
    | (d, true) when d = 0 -> (push (1 + pop ps) ps; (al, ps, false, al))
    | (d, _) when d < 0 -> (
      push (m - fa  + m - al + if fc then pop ps else 0) ps;
      (m, ps, true, al) )
    | _,_ -> (bm, ps, fc, fa) )
  (min_int / 2, ps, false, 0)
  sec
;;
Printf.printf "%d\n" @@ stack_fold (fun a b -> a + b) 0 ps / 2;;
Printf.printf "%d" @@ length ps;;
iter (fun a -> Printf.printf " %d" (a / 2)) ps;;
print_newline ()
