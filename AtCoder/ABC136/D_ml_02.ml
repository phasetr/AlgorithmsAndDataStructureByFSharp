(* https://atcoder.jp/contests/abc136/submissions/6788116 *)
let print_array a =
  let _ = Array.iter (Printf.printf "%d ") a in print_newline()

let () =
  let s = read_line() in
  let n = String.length s in
  let ans = Array.make n 0 in
  let rec for_loop i =
    if i = n-1 then ()
    else
      let _ =
        if s.[i] = 'R' && s.[i+1] = 'L' then
          let rec inner_loop_l j =
            if j < 0 || s.[j] != 'R' then ()
            else
              let k = i + (i-j) mod 2 in
              let _ = ans.(k) <- ans.(k) + 1 in
              inner_loop_l (j-1) in
          let rec inner_loop_r j =
            if j == n || s.[j] != 'L' then ()
            else
              let k = i + (j-i) mod 2 in
              let _ = ans.(k) <- ans.(k) + 1 in
              inner_loop_r (j+1) in
          let _ = inner_loop_l i in
          inner_loop_r (i+1) in
      for_loop (i+1) in
  let _ = for_loop 0 in
  print_array ans
