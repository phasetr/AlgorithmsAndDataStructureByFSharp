#r "nuget: FsUnit"
open FsUnit

let solve W (Ta:string[]) =
  Ta |> Array.collect (fun l -> l.Split())
  |> fun wa -> wa.[0..wa.Length-2]
  |> Array.filter (fun w -> w=W)
  |> Array.length
let W = stdin.ReadLine()
let Ta = Console.ReadLine() |> Seq.initInfinite |> Seq.takeWhile ((<>) null)
solve W Ta |> stdout.WriteLine

let W = "computer"
let Ta = [|"Nurtures computer scientists and highly skilled computer engineers";"who will create and exploit knowledge for the new era";"Provides an outstanding computer environment";"END_OF_TEXT"|]
solve W Ta |> should equal 3
