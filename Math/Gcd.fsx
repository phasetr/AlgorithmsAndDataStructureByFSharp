#r "../packages/NUnit/lib/netstandard2.0/nunit.framework.dll"
#r "../packages/FsUnit/lib/netstandard2.0/FsUnit.NUnit.dll"
#r "../packages/FSharp.Core/lib/netstandard2.0/FSharp.Core.dll"
// http://judge.u-aizu.ac.jp/onlinejudge/description.jsp?id=ALDS1_1_B&lang=ja
// http://judge.u-aizu.ac.jp/onlinejudge/review.jsp?rid=2116711#1
open NUnit.Framework
open FsUnit

module MyGcd =
    let mygcd: int64 -> int64 -> int64 =
        fun x y ->
            let rec locgcd x y =
                match y with
                | 0L -> x
                | _ -> locgcd y (x % y)

            if x >= y then locgcd x y else locgcd y x

    // test
    mygcd 147L 105L |> should equal 21L

// https://docs.microsoft.com/ja-jp/dotnet/fsharp/tour
// https://alexatnet.com/hr-f-computing-the-gcd/
module GcdSample =
    // https://alexatnet.com/hr-f-computing-the-gcd/
    let rec gcd: int64 -> int64 -> int64 =
        fun a b ->
            if a = 0L then b
            elif a < b then gcd a (b - a)
            else gcd (a - b) b

    // test
    gcd 147L 105L |> should equal 21L
