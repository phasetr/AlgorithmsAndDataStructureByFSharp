// https://atcoder.jp/contests/code-festival-2017-quala/submissions/1619442
open System
open System.Collections.Generic

module InputUtility =
    let InputTokens = new Queue<string>()

    let EnsureInput () =
        if InputTokens.Count = 0 then
            let input = Console.ReadLine ()
            let s = input.Split ([|' '|], StringSplitOptions.RemoveEmptyEntries)
            if s.Length > 0 then
                for x in s do InputTokens.Enqueue(x)
                true
            else false
        else true

    let rec ReadNext () =
        if EnsureInput () then InputTokens.Dequeue ()
        else ReadNext ()

    let ReadNextInt () = ReadNext () |> int

    let Read2Int () = ReadNextInt (), ReadNextInt ()

    let Read3Int () = ReadNextInt (), ReadNextInt (), ReadNextInt ()

    let ReadListOf f n =
        let rec loop acc = function
            | 0 -> List.rev acc
            | c -> loop ((ReadNext () |> f) :: acc) (c-1)
        loop [] n

    let MultipleCaseWithId f =
        let caseNum = ReadNextInt ()
        let rec loop index =
            if index = caseNum then ()
            else
                f index
                loop (index + 1)
        loop 0

    let MultipleCase f = MultipleCaseWithId (fun _ -> f ())

    let ReadList n =
        let rec loop acc = function
            | 0 -> List.rev acc
            | c -> loop (ReadNext () :: acc) (c-1)
        loop [] n

open InputUtility

module _2017QualA =
    let private toBoolStr b = if b then "Yes" else "No"

    let private allPairs s1 s2 = seq { for a in s1 do for b in s2 do yield (a, b) }

    let private PalindromicMatrix () =
        let n, m = Read2Int ()
        let mp =
            let a = Array.zeroCreate 26
            for _ in [1..n] do
                let s = ReadNext ()
                for c in s do
                    let d = (int)c - (int)'a'
                    a.[d] <- a.[d] + 1
            a
        let r1 = (n % 2) * (m % 2)
        let r2 = ((n % 2) * m + (m % 2) * n) / 2 - r1
        let r4 = (n * m - r1 - r2 * 2) / 4
        let s1 = Seq.sumBy (fun d -> d % 2) mp
        let s4 = Seq.sumBy (fun d -> d / 4) mp
        //printfn "mp : %A" mp
        //printfn "%d %d %d | %d %d" r4 r2 r1 s4 s1
        toBoolStr (s1 = r1 && s4 >= r4) |> printfn "%s"

    let Entry = PalindromicMatrix

_2017QualA.Entry ()
