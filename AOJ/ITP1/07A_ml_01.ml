(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_7_A/review/1839800/superluminalsloth/OCaml *)
let rec grading g =
  let s = Scanf.scanf "%d %d %d\n" (fun x y z->(x,y,z)) in
  let grade = function
    | (-1,-1,-1) -> g
    | (-1,_,_) | (_,-1,_) -> grading (g^"F\n")
    | (m,f,r) when m+f >= 80 -> grading (g^"A\n")
    | (m,f,r) when m+f >= 65 -> grading (g^"B\n")
    | (m,f,r) when m+f >= 50 -> grading (g^"C\n")
    | (m,f,r) when m+f >= 30 && r >= 50 -> grading (g^"C\n")
    | (m,f,r) when m+f >= 30 -> grading (g^"D\n")
    | (m,f,r) when m+f < 30 -> grading (g^"F\n")
    | _ -> ""
  in grade s;;
let () = grading "" |> print_string;;
