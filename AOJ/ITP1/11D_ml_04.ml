(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_11_D/review/5477780/que0/OCaml *)
let rec sep_sp_i str =
  let ts = String.trim str in
  match String.index_from (ts ^ " ") 0 ' ' with
  | 0 -> []
  | a -> int_of_string (String.sub ts 0 a) :: (sep_sp_i (String.sub ts a (String.length ts - a))) ;;

type dice = {tp : int; sd : int array; bt : int}

let dice_body = [
    {tp=1;sd=[|2;3;5;4|];bt=6};
    {tp=2;sd=[|1;4;6;3|];bt=5};
    {tp=3;sd=[|1;2;6;5|];bt=4};
    {tp=4;sd=[|1;5;6;2|];bt=3};
    {tp=5;sd=[|1;3;6;4|];bt=2};
    {tp=6;sd=[|2;4;5;3|];bt=1}
  ]

let rotate_sd sd = Array.append (Array.sub sd 1 3) (Array.sub sd 0 1)
let rotate_dice dice = {tp = dice.tp; sd = rotate_sd dice.sd; bt = dice.bt}
let rotate_quad_dice dice =
  let d2 = rotate_dice dice in
  let d3 = rotate_dice d2 in
  let d4 = rotate_dice d3 in
  [d4; d3; d2; dice]
let rqdl dl = List.concat @@ List.map rotate_quad_dice dl
let list_min ls = List.fold_left min (List.hd ls) ls
let dice_map f dice = {tp = f dice.tp; sd = Array.map f dice.sd; bt = f dice.bt}
let label_dice labels_array dice = dice_map (fun n -> labels_array.(n-1)) dice

let n = read_int ();;
let rec make_dice_n n =
  if n <= 0 then []
  else
    let labels_a = Array.of_list @@ sep_sp_i (read_line ()) in
    let dice_fixed = list_min @@ rqdl @@ List.map (label_dice labels_a) dice_body in
    dice_fixed :: make_dice_n (n - 1) in
    let dice_list = make_dice_n n in
    print_endline @@ if n = List.length (List.sort_uniq compare dice_list) then "Yes" else "No"
