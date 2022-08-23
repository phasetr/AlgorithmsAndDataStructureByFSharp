(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_3_D/review/2420165/rabbisland/OCaml *)
let () =
  let s = read_line () in
  let li = Stack.create () in
  let res = Stack.create () in
  let rec get i a =
    if Stack.is_empty res then a
    else let (j, x) = Stack.pop res in
         if j < i then begin
             Stack.push (j, x) res;
             a
           end
         else begin
             get i (a+x)
           end in
  let rec to_list st ls =
    if Stack.is_empty st then ls
    else let (_, x) = Stack.pop st in to_list st (x::ls) in
  String.iteri (fun i c ->
      if c = '\\' then Stack.push i li
      else if c = '/' then begin
          if Stack.is_empty li then ()
          else let j = Stack.pop li in
               let m = get j 0 in
               Stack.push (j, m + i - j) res
        end
    ) s;
  let l = to_list res [] in
  List.fold_left (+) 0 l |> string_of_int |> print_endline;
  (List.length l) :: l |> List.map string_of_int |> String.concat " " |> print_endline
