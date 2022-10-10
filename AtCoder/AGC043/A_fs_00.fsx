#r "nuget: FsUnit"
open FsUnit

let H,W,Sa = 3,3,[|".##";".#.";"##."|]
let solve H W (Sa:string[]) =
  let M = System.Int32.MaxValue
  let rec loop i j (dp:int[,]) =
    if i=H then dp.[H-1,W-1]
    else
      let a = if i>0 then (dp.[i-1,j] + if Sa.[i-1].[j]='.' && Sa.[i].[j]='#' then 1 else 0) else M
      let b = if j>0 then (dp.[i,j-1] + if Sa.[i].[j-1]='.' && Sa.[i].[j]='#' then 1 else 0) else M
      Array2D.set dp i j (min a b)
      if j = W-1 then loop (i+1) 0 dp else loop i (j+1) dp
  let dp = Array2D.create H W 0
  if Sa.[0].[0]='#' then Array2D.set dp 0 0 1; dp else dp
  |> loop 0 1

let H,W = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0],x.[1])
let Sa = [| for i in 1..H do stdin.ReadLine() |]
solve H W Sa |> stdout.WriteLine

solve 3 3 [|".##";".#.";"##."|] |> should equal 1
solve 2 2 [|"#.";".#"|] |> should equal 2
solve 4 4 [|"..##";"#...";"###.";"###."|] |> should equal 0
solve 5 5 [|".#.#.";"#.#.#";".#.#.";"#.#.#";".#.#.";|] |> should equal 4
