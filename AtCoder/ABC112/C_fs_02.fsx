// https://atcoder.jp/contests/abc112/submissions/9955299
let inputs =
    Array.init (stdin.ReadLine() |> int) (fun _ ->
        stdin.ReadLine().Split()
        |> Array.map int
        |> function [|x; y; h|] -> (x, y), h | _ -> failwith "input error")
let xy0, h0 = inputs |> Array.find (snd >> (<>) 0)
let manhattan (x1, y1) (x2, y2) = abs (x1 - x2) + abs (y1 - y2)
let (cx, cy), h =
    seq { for cx in 0 .. 100 do for cy in 0 .. 100 -> cx, cy }
    |> Seq.map (fun center -> center, manhattan center xy0 + h0)
    |> Seq.find (fun (center, height) ->
        let heightAt xy = height - manhattan center xy |> max 0
        inputs |> Array.forall (fun (xy, h) -> heightAt xy = h))
printfn "%d %d %d" cx cy h
