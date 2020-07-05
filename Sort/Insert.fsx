#r "../packages/NUnit/lib/netstandard2.0/nunit.framework.dll"
#r "../packages/FsUnit/lib/netstandard2.0/FsUnit.NUnit.dll"
#r "../packages/FSharp.Core/lib/netstandard2.0/FSharp.Core.dll"
// cf. https://qiita.com/7shi/items/1e2a66bf8e8c7f0bd70f
open NUnit.Framework
open FsUnit

// http://www.fssnip.net/e9/title/Insertion-Sort-on-List
module Insert1 =
    // An insert function
    let insert x lst =
        let rec insertCont x cont =
            function
            | [] -> cont ([ x ])
            | h :: t as l ->
                if x <= h
                then cont (x :: l)
                else insertCont x (fun accLst -> cont (h :: accLst)) t

        insertCont x id lst

    // Sorting via insertion
    let insertionSort l =
        let rec insertionSortAcc acc =
            function
            | [] -> acc
            | h :: t -> insertionSortAcc (insert h acc) t

        insertionSortAcc [] l

// https://stackoverflow.com/questions/9518850/insertion-sort-implementation-with-one-recursive-function-and-foldback-function
module Insert2 =
    let rec insert x =
        function
        | [] -> [ x ]
        | y :: ys -> if x <= y then x :: y :: ys else y :: (insert x ys)

    and insertionSort =
        function
        | [] -> []
        | x :: xs -> insert x (insertionSort xs)

module Insert3 =
    let rec insert x =
        function
        | [] -> [ x ]
        | y :: ys -> if x <= y then x :: y :: ys else y :: (insert x ys)

    let rec insertionSort =
        function
        | [] -> []
        | x :: xs -> insert x (insertionSort xs)

let lst = [ 24; 33; -5; -16; 0 ]
let sorted = [ -16; -5; 0; 24; 33 ]
Insert1.insertionSort lst |> should equal sorted
Insert2.insertionSort lst |> should equal sorted
Insert3.insertionSort lst |> should equal sorted
