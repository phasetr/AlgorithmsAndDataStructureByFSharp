(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_3_A/review/2041185/ydash/OCaml *)
let () =
  let l = read_line () |> Str.split (Str.regexp " ") in
  let s = Stack.create () in
  let interpret_op = function "+" -> (+) | "-" -> (-) | _ -> ( * ) in
  List.iter
    (fun x -> match x with
                "+" | "*" | "-" ->
                       let a,b = Stack.pop s, Stack.pop s in
                       Stack.push ((interpret_op x) a b) s
                | _ -> Stack.push (int_of_string x) s)
    l;
  Printf.printf "%d\n" (Stack.pop s)
