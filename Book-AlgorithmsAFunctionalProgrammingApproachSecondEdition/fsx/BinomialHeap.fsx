#r "nuget: FsUnit"
open FsUnit

type 'a Tree = Node of int * 'a * 'a list
type 'a Heap = BH of 'a Tree
