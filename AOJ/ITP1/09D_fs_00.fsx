#r "nuget: FsUnit"
open FsUnit

let print (str:string) a b = (str.Substring(a,b-a+1) |> stdout.WriteLine); str
let replace str a b (p:string) = String.mapi (fun i c -> if a <= i && i <= b then p.[i-a] else c) str
let reverse (str:string) a b = String.mapi (fun i c -> if a <= i && i <= b then str.[a-i+b] else c) str

let rec solve S = function
  | [] -> ()
  | (h:string[])::t ->
    match h.[0] with
      | "reverse" -> let a = int h.[1] in let b = int h.[2] in solve (reverse S a b) t
      | "replace" -> let a = int h.[1] in let b = int h.[2] in let p = h.[3] in solve (replace S a b p) t
      | _ -> let a = int h.[1] in let b = int h.[2] in solve (print S a b) t

let N = stdin.ReadLine() |> int
let Xa = [| for i in 1..N do stdin.ReadLine().Split() |]
solve S Xa

// TEST
let S = "abcde"
let Xa = [[|"replace";"1";"3";"xyz"|];[|"reverse";"0";"2"|];[|"print";"1";"4"|]]
solve S Xa
// TEST
let S = "xyz"
let Xa = [[|"print";"0";"2"|];[|"replace";"0";"2";"abc"|];[|"print";"0";"2"|]]
solve S Xa
