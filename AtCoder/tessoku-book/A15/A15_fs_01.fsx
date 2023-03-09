// https://atcoder.jp/contests/tessoku-book/submissions/37967100
let N = stdin.ReadLine() |> int
let A = stdin.ReadLine().Trim().Split() |> Array.map int

let T = A |> Set.ofArray |> Set.toArray |> Array.sort

let binarySearch x (ary : int[]) =
    let rec binarySearchSub ng ok =
        if ok - ng > 1 then
            let mid = (ng + ok) / 2
            if ary.[mid] >= x then
                binarySearchSub ng mid
            else
                binarySearchSub mid ok
        else
            ok
    binarySearchSub -1 ary.Length

let B = Array.map (fun a -> binarySearch a T + 1) A

printf "%d" B.[0]
for i = 1 to N - 1 do
    printf " %d" B.[i]
