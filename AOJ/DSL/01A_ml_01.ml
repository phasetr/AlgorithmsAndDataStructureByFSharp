(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/DSL_1_A/review/2460953/r6eve/OCaml *)
let split_on_char sep s =
  let open String in
  let r = ref [] in
  let j = ref (length s) in
  for i = length s - 1 downto 0 do
    if get s i = sep then begin
        r := sub s (i + 1) (!j - i - 1) :: !r;
        j := i
      end
  done;
  sub s 0 !j :: !r

let readln () = read_line () |> split_on_char ' ' |> List.map int_of_string

let solve n q =
  let s = Array.init n (fun i -> i) in
  let rec find u =
    if u = s.(u) then u
    else begin
        s.(u) <- find s.(u);
        s.(u)
      end in
  for _ = 0 to q - 1 do
    match readln () with
    | n :: x :: y :: _ ->
       if n = 0 then s.(find x) <- find y
       else print_endline (if find x = find y then "1" else "0")
    | _ -> assert false
  done

let () =
  match readln () with
  | [n; q] -> solve n q
  | _ -> assert false
