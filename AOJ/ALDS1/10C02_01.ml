(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_10_C/review/2453589/rabbisland/OCaml *)
let lcs s1 s2 =
  let l1 = String.length s1 in
  let l2 = String.length s2 in
  let dp = Array.make_matrix (l1+1) (l2+1) 0 in
  let rec iter i j =
    if i = l1 + 1 then dp.(l1).(l2)
    else if j = l2 + 1 then iter (i+1) 1
    else begin
        if s1.[i-1] = s2.[j-1] then
          dp.(i).(j) <- dp.(i-1).(j-1) + 1
        else
          dp.(i).(j) <- max dp.(i-1).(j) dp.(i).(j-1);
        iter i (j+1)
      end
  in iter 1 1

let () =
  let n = read_int () in
  let rec iter i =
    if i = 0 then ()
    else
      let s1 = read_line () in
      let s2 = read_line () in
      lcs s1 s2 |> string_of_int |> print_endline;
      iter (i-1)
  in iter n
