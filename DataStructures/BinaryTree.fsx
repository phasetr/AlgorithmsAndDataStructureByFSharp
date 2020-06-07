(*
https://en.wikibooks.org/wiki/F_Sharp_Programming/Advanced_Data_Structures#Binary_Search_Trees
Binary Search Tree
*)

module Tree =
    type 'a Tree =
        | EmptyTree
        | TreeNode of 'a * 'a Tree * 'a Tree

    let hd =
        function
        | EmptyTree -> failwith "empty"
        | TreeNode (hd, l, r) -> hd

    let rec exists item =
        function
        | EmptyTree -> false
        | TreeNode (hd, l, r) ->
            if hd = item then true
            elif item < hd then exists item l
            else exists item r

    let rec insert item =
        function
        | EmptyTree -> TreeNode(item, EmptyTree, EmptyTree)
        | TreeNode (hd, l, r) as node ->
            if hd = item then node
            elif item < hd then TreeNode(hd, insert item l, r)
            else TreeNode(hd, l, insert item r)



open Tree

type BinaryTree<'a when 'a: comparison>(inner: 'a Tree) =
    member this.Hd = Tree.hd inner
    member this.Exists item = Tree.exists item inner
    member this.Insert item = BinaryTree(Tree.insert item inner)
    static member empty = BinaryTree<'a>(EmptyTree)

// test
[ 1 .. 7 ]
|> Seq.fold (fun (t: BinaryTree<_>) x -> t.Insert(x)) BinaryTree.empty
