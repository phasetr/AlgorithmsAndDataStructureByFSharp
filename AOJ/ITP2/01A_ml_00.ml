#load "str.cma"
open String
let pushBack x xs = Array.append xs [|x|]
let randomAccess x xs = xs.(x)
let popBack xs = Array.sub xs 0 (Array.length xs - 1)

let () =
  pushBack 1 [|1;2|]; (* [|1;2;1|] *)
  pushBack 3 [|1;2|]; (* [|1;2;3|] *)
  randomAccess 0 [|1;2;3|]; (* 1 *)
  randomAccess 1 [|1;2;3|]; (* 2 *)
  randomAccess 2 [|1;2;3|]; (* 3 *)
  popBack [|1;2;3|]; (* [|1;2|] *)
  popBack [|1;2|]; (* [|1|] *)
  String.split_on_char ' ' "0 1" |> List.map int_of_string;
