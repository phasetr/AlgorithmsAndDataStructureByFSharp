#r "nuget: FsUnit"
open FsUnit

let solve aa =
  let mutable sa = Array.init 13 (fun i -> (i+1,true))
  let mutable ha = Array.init 13 (fun i -> (i+1,true))
  let mutable ca = Array.init 13 (fun i -> (i+1,true))
  let mutable da = Array.init 13 (fun i -> (i+1,true))
  for (s,r) in aa do
    match s with
      | "S" -> sa.[r-1] <- (r,false)
      | "H" -> ha.[r-1] <- (r,false)
      | "C" -> ca.[r-1] <- (r,false)
      | "D" -> da.[r-1] <- (r,false)
  done
  let f c xa = xa |> Array.choose (fun (r,b) -> if b then Some(sprintf "%c %d" c r) else None)
  Array.concat [|f 'S' sa; f 'H' ha; f 'C' ca; f 'D' da|]

let n = stdin.ReadLine() |> int
let aa = [| for i in 1..n do (stdin.ReadLine().Split() |> fun x -> x.[0], int x.[1]) |]
solve aa |> String.concat "\n" |> stdout.WriteLine

let aa = [|("S",10);("S",11);("S",12);("S",13);("H",1);("H",2);("S",6);("S",7);("S",8);("S",9);("H",6);("H",8);("H",9);("H",10);("H",11);("H",4);("H",5);("S",2);("S",3);("S",4);("S",5);("H",12);("H",13);("C",1);("C",2);("D",1);("D",2);("D",3);("D",4);("D",5);("D",6);("D",7);("C",3);("C",4);("C",5);("C",6);("C",7);("C",8);("C",9);("C",10);("C",11);("C",13);("D",9);("D",10);("D",11);("D",12);("D",13)|]
solve aa |> should equal [|"S 1";"H 3";"H 7";"C 12";"D 8"|]
