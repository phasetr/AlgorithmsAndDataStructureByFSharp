(* https://atcoder.jp/contests/agc043/submissions/13277038 *)
let split_string ?(pattern="") = Str.split @@ Str.regexp pattern

let (h, w) = Scanf.sscanf (read_line ()) "%d %d" @@ fun h w -> (h, w)
let s = Array.init h @@ fun _ -> Array.of_list @@ split_string @@ read_line ()

let rec loop dp i j =
  if i = h then Printf.printf "%d\n" dp.(h - 1).(w - 1)
  else begin
      dp.(i).(j) <- min
                      (if i > 0 then (dp.(i - 1).(j) + if s.(i - 1).(j) = "." && s.(i).(j) = "#" then 1 else 0) else max_int)
                      (if j > 0 then (dp.(i).(j - 1) + if s.(i).(j - 1) = "." && s.(i).(j) = "#" then 1 else 0) else max_int);
      if j = w - 1 then loop dp (i + 1) 0 else loop dp i (j + 1)
    end

let () =
  let dp = Array.init h @@ fun _ -> Array.make w 0 in
  if s.(0).(0) = "#" then dp.(0).(0) <- 1;
  loop dp 0 1
