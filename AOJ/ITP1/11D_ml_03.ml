(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_11_D/review/4034461/Wasedadaigaku/OCaml *)
let () =
  let n = read_int () in
  let read_dice () = Scanf.sscanf (read_line ()) "%d %d %d %d %d %d" (fun a b c d e f -> [(a,f);(b,e);(c,d)]) in
  let rec loop dices result = function
    | 0 -> result
    | i -> let dice2 = read_dice () in
           let is_same_dice dice1 dice2 =
             let rec scan_through dice2 bop = function
               | 0 -> false
               | i ->
                  let scan' dice2 bop =
                    let r1,r2 = List.fold_left2 (
                                    fun (r1,r2) (a,b) (c,d) ->
                                    let b1,b2 = (a = c && b = d), (a = d && b = c) in
                                    if b1 && b2 then 1, true
                                    else if b1 then 1 * r1, r2
                                    else if b2 then -1 * r1, r2
                                    else 0, false
                                  ) (1,false) dice1 dice2 in
                    bop r1 0 || (r1 <> 0 && r2 ) in
                  scan' dice2 bop || ( i > 1 && let dice2' = (List.tl dice2) @ [(List.hd dice2)] in scan_through dice2' bop (i-1)) in
             scan_through dice2 (>) 3 || scan_through (List.rev dice2) (<) 3
           in
           let result' = List.fold_left (fun acc dice -> acc || (is_same_dice dice dice2) ) false dices in
           result' || loop (dice2::dices) result' (i-1) in
  let dice1 = read_dice () in
  print_string @@ if loop [dice1] false (n-1) then "No\n" else "Yes\n"
