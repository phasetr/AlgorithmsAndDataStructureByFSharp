(* https://atcoder.jp/contests/abc113/submissions/3534284 *)
let () =
  Scanf.scanf "%d %d" @@
    fun n m ->
    let towns = Array.init m (fun i ->
                    Scanf.scanf " %d %d" @@ fun p y -> y, i, p) in
    let l6 = Array.make n 1 in
    let answers = Array.make m "" in
    Array.sort compare towns;
    towns |> Array.iter (fun (y,i,p) ->
                 answers.(i) <-
                   Printf.sprintf "%06d%06d" p l6.(p-1);
                 l6.(p-1) <- l6.(p-1) + 1);
    answers |> Array.iter print_endline
