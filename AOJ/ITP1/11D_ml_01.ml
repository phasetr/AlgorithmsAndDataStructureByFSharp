(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_11_D/review/2474874/rabbisland/OCaml *)
open Printf
open Scanf

let id x = x

module Dice =
  struct
    type t = {tp:int; ft:int; lt:int; rt:int; bk:int; bm:int}

    let create x1 x2 x3 x4 x5 x6 =
      {tp = x1; ft = x2; lt = x3; rt = x4; bk = x5; bm = x6}

    let roll d = function
      | 'S' -> {d with tp = d.bk; ft = d.tp; bm = d.ft; bk = d.bm}
      | 'E' -> {d with tp = d.rt; lt = d.tp; bm = d.lt; rt = d.bm}
      | 'W' -> {d with tp = d.lt; rt = d.tp; bm = d.rt; lt = d.bm}
      | 'N' -> {d with tp = d.ft; bk = d.tp; bm = d.bk; ft = d.bm}
      | _ -> failwith "roll"

    let rollx d dirs =
      let rd = ref d in
      String.iter (fun c -> rd := roll !rd c) dirs;
      !rd

    let equal d1 d2 =
      let ht = Hashtbl.create 100 in
      let rec dfs d =
        if Hashtbl.mem ht d then false
        else
          if d1 = d then true
          else begin
              Hashtbl.add ht d true;
              List.fold_left (fun b c ->
                  if b then b
                  else dfs (roll d c)
                ) false ['N';'E';'W';'S']
            end
      in dfs d2

    let top d = d.tp
    let front d = d.ft
    let left d = d.lt
  end

let () =
  let n = scanf "%d " id in
  let rec read x =
    if x = 0 then []
    else let d = scanf "%d %d %d %d %d %d " Dice.create in
         d :: (read (x-1)) in
  let ds = read n in
  let rec iter = function
      [] -> "Yes"
    | h :: t -> if List.exists (fun d -> Dice.equal h d) t then "No" else iter t in
  iter ds |> printf "%s\n"
