(* https://atcoder.jp/contests/abc076/submissions/1720303 *)
open Printf
open Scanf

let () =
  let sd = scanf "%s " (fun x -> x) in
  let t = scanf "%s " (fun x -> x) in
  let sdl = String.length sd in
  let tl = String.length t in
  let mts i =
    let rec loop j =
      if j = tl then true
      else if sd.[i+j] = '?' || t.[j] = sd.[i+j] then loop (j + 1)
      else false in
    loop 0 in
  let rec loop i =
    if i < 0 then "UNRESTORABLE"
    else if mts i then let s1 = String.concat "" [String.sub sd 0 i ; t ; String.sub sd (i + tl) (sdl - i - tl)] in
                       String.init sdl (fun j -> if s1.[j] = '?' then 'a' else s1.[j])
    else loop (i - 1) in
  loop (sdl - tl) |> printf "%s\n"
