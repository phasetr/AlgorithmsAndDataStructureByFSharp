// https://en.wikibooks.org/wiki/F_Sharp_Programming/Advanced_Data_Structures#Red_Black_Trees
type Color =
    | R
    | B

type 'a Tree =
    | E
    | T of Color * 'a Tree * 'a * 'a Tree

module Tree =
    let hd =
        function
        | E -> failwith "empty"
        | T (c, l, x, r) -> x

    let left =
        function
        | E -> failwith "empty"
        | T (c, l, x, r) -> l

    let right =
        function
        | E -> failwith "empty"
        | T (c, l, x, r) -> r

    let rec exists item =
        function
        | E -> false
        | T (c, l, x, r) ->
            if item = x then true
            elif item < x then exists item l
            else exists item r

    let balance =
        function
        (* Red nodes in relation to black root *)
        | B, T (R, T (R, a, x, b), y, c), z, d (* Left, left *)
        | B, T (R, a, x, T (R, b, y, c)), z, d (* Left, right *)
        | B, a, x, T (R, T (R, b, y, c), z, d) (* Right, left *)
        | B, a, x, T (R, b, y, T (R, c, z, d)) (* Right, right *)  -> T(R, T(B, a, x, b), y, T(B, c, z, d))
        | c, l, x, r -> T(c, l, x, r)

    let insert item tree =
        let rec ins =
            function
            | E -> T(R, E, item, E)
            | T (c, a, y, b) as node ->
                if item = y then node
                elif item < y then balance (c, ins a, y, b)
                else balance (c, a, y, ins b)

        (* Forcing root node to be black *)
        match ins tree with
        | E -> failwith "Should never return empty from an insert"
        | T (_, l, x, r) -> T(B, l, x, r)

    let rec print (spaces: int) =
        function
        | E -> ()
        | T (c, l, x, r) ->
            print (spaces + 4) r
            printfn "%s %A%A" (System.String(' ', spaces)) c x
            print (spaces + 4) l

type BinaryTree<'a when 'a : comparison>(inner: 'a Tree) =
    member this.Hd = Tree.hd inner
    member this.Left = BinaryTree(Tree.left inner)
    member this.Right = BinaryTree(Tree.right inner)
    member this.Exists item = Tree.exists item inner
    member this.Insert item = BinaryTree(Tree.insert item inner)
    member this.Print() = Tree.print 0 inner
    static member empty = BinaryTree<'a>(E)
