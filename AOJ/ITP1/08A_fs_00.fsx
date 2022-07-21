#r "nuget: FsUnit"
open FsUnit

let S = "fAIR, LATER, OCCASIONALLY CLOUDY."
let solve = String.map (fun c -> if System.Char.IsUpper c then System.Char.ToLower c else System.Char.ToUpper c)

let S = stdin.ReadLine()
solve S |> stdout.WriteLine

solve "fAIR, LATER, OCCASIONALLY CLOUDY." |> should equal "Fair, later, occasionally cloudy."
