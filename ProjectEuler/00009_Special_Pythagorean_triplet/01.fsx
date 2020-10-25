// # Special Pythagorean triplet
// - [URL](https://projecteuler.net/problem=9)
// ## Problem 9
// A Pythagorean triplet is a set of three natural numbers, a < b < c, for which,
// $a^2 + b^2 = c^2$.
// For example, 32 + 42 = 9 + 16 = 25 = 52.
// There exists exactly one Pythagorean triplet for which a + b + c = 1000.
// Find the product abc.
//
// ピタゴラスの三つ組みは $a < b < c$ かつ $a^2 + b^2 = c^2$ をみたす 3 つの自然数の集合を指す。
// ここで $a+b+c=1000$$ をみたす三つ組みはただ1つしかない。
// このときの積 $abc$ を求めよ。

let solve n =
    seq {
        for a in 1..n do
        for b in a..n do
        let c = n - a - b
        yield if (pown a 2) + (pown b 2) = pown c 2 then ((a,b,c), a*b*c) else ((0,0,0),0)
    }
    |> Seq.filter (fun x -> x <> ((0,0,0), 0))
    |> Array.ofSeq

solve 1000 |> printfn "%A"
