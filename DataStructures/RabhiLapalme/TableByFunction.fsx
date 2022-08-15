// Rabhi-Lapalme, P.98, 5.6 Tables
// A table allows values to be stored and retrieved according to an index.
// I.e., a table implements a function of type (b -> a) by means of a data structure
// instead of an algorithm.
// The operation newTable takes a list of ( index , value) pairs
// and returns the cor­responding table.

// P.98 5.6.1 Implementing a table as a function
module TableByFunction =
    // newtype Table a b = Tbl (b -> a)
    type Table<'a, 'b> = 'b -> 'a

    //let findTable (f: Table) i = f i
    let findTable (f: Table<'a, 'b>) (i: 'b) = f i

    let updTable (i,x) (f: Table<'a, 'b>) =
        fun j -> if j = i then x else f j

    // TODO
    // let newTable assocs =
