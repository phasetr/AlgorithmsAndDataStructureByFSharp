#r "../../packages/NUnit/lib/netstandard2.0/nunit.framework.dll"
#r "../../packages/FsUnit/lib/netstandard2.0/FsUnit.NUnit.dll"
#r "../../packages/FSharp.Core/lib/netstandard2.0/FSharp.Core.dll"
// http://judge.u-aizu.ac.jp/onlinejudge/description.jsp?id=ALDS1_1_B&lang=ja
// http://judge.u-aizu.ac.jp/onlinejudge/review.jsp?rid=2116711#1
open NUnit.Framework
open FsUnit

module MyGcd1 =
    let gcd: int64 -> int64 -> int64 =
        fun x y ->
            let rec locgcd x y =
                match y with
                | 0L -> x
                | _ -> locgcd y (x % y)

            if x >= y then locgcd x y else locgcd y x

    let lcm a b = a * b / (gcd a b)

    // test
    gcd 147L 105L |> should equal 21L

// https://docs.microsoft.com/ja-jp/dotnet/fsharp/tour
// https://alexatnet.com/hr-f-computing-the-gcd/
module MyGcd2 =
    // https://alexatnet.com/hr-f-computing-the-gcd/
    let rec gcd: int64 -> int64 -> int64 =
        fun a b ->
            if a = 0L then b
            elif a < b then gcd a (b - a)
            else gcd (a - b) b

    let lcm a b = a * b / (gcd a b)

    // test
    gcd 147L 105L |> should equal 21L

// ../ProjectEuler/00005_Smallest_multiple/01.fsx
module MyGcd3 =
    let rec gcd a b =
        let (s, l) = if a < b then (a, b) else (b, a)
        let r = l % s
        if r = 0L then s else gcd r s

    let lcm a b = a * b / (gcd a b)

    // test
    gcd 147L 105L |> should equal 21L
    lcm 2L 7L |> should equal 14L
