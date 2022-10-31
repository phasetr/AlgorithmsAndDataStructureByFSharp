(* https://atcoder.jp/contests/abc069/submissions/9944688 *)
let k, css, h, w, a_s = Scanf.scanf "%d %d %d" @@ fun h w n -> Array.(ref 0, make_matrix h w 0, h, w, init n @@ fun _ -> Scanf.scanf " %d" (+) 0)
let _ =
  for i = 0 to h - 1 do
    for j = 0 to w - 1 do
      if a_s.(!k) = 0 then incr k; css.(i).(if i mod 2 = 0 then j else w - 1 - j) <- !k + 1; a_s.(!k) <- a_s.(!k) - 1
    done
  done;
  Array.(iter (fun ns -> to_list ns |> List.map string_of_int |> String.concat " " |> print_endline) css)
