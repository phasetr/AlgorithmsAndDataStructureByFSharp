#r "nuget: FsUnit"
open FsUnit

let solve Xa =
  let dict = System.Collections.Generic.Dictionary<string,bool>()
  for (command, dna) in Xa do
    if command="insert" then dict.Add(dna,true)
    else
      match dict.TryGetValue(dna) with
        | true, _ -> stdout.WriteLine "yes"
        | _ -> stdout.WriteLine "no"
  done

let Xa = [| for i in 1..N do (stdin.ReadLine().Split |> fun (x -> x.[0],x.[1])) |]
solve Xa

solve [|("insert","AAA");("insert","AAC");("find","AAA");("find","CCC");("insert","CCC");("find","CCC")|]
// yes no yes
solve [|("insert","AAA");("insert","AAC");("insert","AGA");("insert","AGG");("insert","TTT");("find","AAA");("find","CCC");("find","CCC");("insert","CCC");("find","CCC");("insert","T");("find","TTT");("find","T")|]
// yes no no yes yes yes
