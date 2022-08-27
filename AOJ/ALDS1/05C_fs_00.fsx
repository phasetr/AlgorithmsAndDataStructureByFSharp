#r "nuget: FsUnit"
open FsUnit
open System.Numerics

let solve N =
  let rot = Complex(0.5, Math.Sqrt(3) / 2.0)
  let rec kc n p1 p2 =
    if n>0 then
      let ls = (p2-p1) / (Complex(3,0))
      let s = p1 + ls
      let t = p2 - ls
      let u = s + (ls * rot)
      let m = n-1
      List.collect id [kc m p1 s; kc m s u; kc m u t; kc m t p2]
    else [p2]
  kc N (Complex(0,0)) (Complex(100,0))
  |> List.map (fun x -> (x.Real, x.Imaginary)) |> fun x -> (0.0,0.0)::x

let N = stdin.ReadLine() |> int
solve N |> stdout.WriteLine

let near0 x y = (abs (x-y)) < 0.000_1

solve 0 |> should equal [(0.0,0.0); (100.0,0.0)]
let solution1 = [(0.0, 0.0); (33.33333333, 0.0); (50.0, 28.86751346); (66.66666667, 0.0); (100.0, 0.0)]
List.map2 (fun x y -> (near0 (fst x) (fst y)) && (near0 (snd x) (snd y))) (solve 1) solution1 |> List.forall id |> should be True
let solution2 = [(0.00000000,0.00000000);(11.11111111,0.00000000);(16.66666667,9.62250449);(22.22222222,0.00000000);(33.33333333,0.00000000);(38.88888889,9.62250449);(33.33333333,19.24500897);(44.44444444,19.24500897);(50.00000000,28.86751346);(55.55555556,19.24500897);(66.66666667,19.24500897);(61.11111111,9.62250449);(66.66666667,0.00000000);(77.77777778,0.00000000);(83.33333333,9.62250449);(88.88888889,0.00000000);(100.00000000,0.00000000)]
List.map2 (fun x y -> (near0 (fst x) (fst y)) && (near0 (snd x) (snd y))) (solve 2) solution2 |> List.forall id |> should be True
