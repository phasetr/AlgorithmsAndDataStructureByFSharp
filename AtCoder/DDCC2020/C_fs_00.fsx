#r "nuget: FsUnit"
open FsUnit

let H,W,K,Sa = 3,3,5,[|"#.#";".#.";"#.#"|]
let H,W,K,Sa = 3,3,3,[|"...";".##";"..#"|]
let solve H W K (Sa:string[]) =
  let cakes = Sa |> Array.map (fun s -> Seq.contains '#' s)
  let mutable num = 1
  let mutable Aa = Array2D.create H W 0
  Sa |> Array.iteri (fun i s ->
    if cakes.[i] then
      for j=0 to W-1 do
        if s.[j] = '#' then Aa.[i,j] <- num; num <- num+1
        else if j>0 && Aa.[i,j-1] > 0 then Array2D.set Aa i j Aa.[i,j-1]
      done
      for j=W-2 downto 0 do
        if Aa.[i,j] = 0 then Array2D.set Aa i j Aa.[i,j+1]
      done)
  for i=0 to W-1 do
    for j=1 to H-1 do
      if Aa.[j,i] = 0 && Aa.[j-1,i] >0 then Array2D.set Aa j i Aa.[j-1,i]
    done
    for j=H-2 downto 0 do
      if Aa.[j,i] = 0 && Aa.[j+1,i] >0 then Array2D.set Aa j i Aa.[j+1,i]
    done
  done
  [|0..H-1|] |> Array.map (fun i -> Aa.[i,*] |> Array.map string |> String.concat " ")

let H,W,K = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0],x.[1],x.[2])
let Sa = [| for i in 1..H do (stdin.ReadLine()) |]
solve H W K Sa |> String.concat "\n" |> stdout.WriteLine

solve 3 3 5 [|"#.#";".#.";"#.#"|] |> String.concat "\n"
"""
1 2 2
1 3 4
5 5 4
"""
solve 3 3 3 [|"...";".##";"..#"|] |> String.concat "\n"
"""
1 1 2
1 1 2
3 3 3
"""
solve 3 7 7 [|"#...#.#";"..#...#";".#..#.."|] |> String.concat "\n"
"""
1 1 2 2 3 4 4
6 6 2 2 3 5 5
6 6 7 7 7 7 7
"""
solve 13 21 106 [|".....................";".####.####.####.####.";"..#.#..#.#.#....#....";"..#.#..#.#.#....#....";"..#.#..#.#.#....#....";".####.####.####.####.";".....................";".####.####.####.####.";"....#.#..#....#.#..#.";".####.#..#.####.#..#.";".#....#..#.#....#..#.";".####.####.####.####.";".....................";|]
