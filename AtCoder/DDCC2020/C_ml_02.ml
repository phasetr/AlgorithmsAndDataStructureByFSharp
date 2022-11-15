(* https://atcoder.jp/contests/ddcc2020-qual/submissions/14489696 *)
let split_string ?(pattern="") = Str.split @@ Str.regexp pattern
let (h, w, k) = Scanf.sscanf (read_line ()) "%d %d %d" @@ fun h w k -> (h, w, k)
let ss = Array.init h @@ fun _ -> read_line ()

let rows = Array.init h @@ fun i -> String.length (Str.global_replace (Str.regexp "[^#]") "" ss.(i)) > 0
let ans = Array.make_matrix h w 0

let () =
  let num = ref 1 in
  Array.iteri (fun i s -> if rows.(i) then begin
    for j = 0 to w - 1 do
      if s.[j] = '#' then begin
        ans.(i).(j) <- !num;
        num := !num + 1
      end else if j > 0 && ans.(i).(j - 1)  > 0 then
        ans.(i).(j) <- ans.(i).(j - 1)
    done;
    for j = w - 2 downto 0 do
      if ans.(i).(j) = 0 then ans.(i).(j) <- ans.(i).(j + 1)
    done
  end) ss;
  for i = 0 to w - 1 do
    for j = 1 to h - 1 do
      if ans.(j).(i) = 0 && ans.(j - 1).(i) > 0 then ans.(j).(i) <- ans.(j - 1).(i)
    done;
    for j = h - 2 downto 0 do
      if ans.(j).(i) = 0 && ans.(j + 1).(i) > 0 then ans.(j).(i) <- ans.(j + 1).(i)
    done
  done;
  Array.iter (fun arr ->
    Array.map string_of_int arr |> Array.to_list |> String.concat " " |> print_endline
  ) ans
