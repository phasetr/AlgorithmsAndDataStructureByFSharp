(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_5_D/review/1838852/superluminalsloth/OCaml *)
let n = read_int ();;
let call n =
  let rec checknum i =
    if i <> 1 && i > n then print_newline ()
    else
      if i mod 3 = 0 then begin
          Printf.printf " %d" i; checknum (i+1)
        end
      else
        let rec include3 j =
          if j mod 10 = 3 then begin
              Printf.printf " %d" i; checknum (i+1)
            end
          else
            let k = j/10 in
            if k > 0 then include3 k else checknum (i+1)
      in include3 i
  in checknum 1;;
let () = call n;;
