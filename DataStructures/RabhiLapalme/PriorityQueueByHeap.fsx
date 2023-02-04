// Rabhi-Lapalme, P.107
#load "Heap.fsx"
open Heap

type PQ<'a when 'a: comparison> = PQ of Heap.Heap<'a>
let emptyPQ = PQ Heap.emptyHeap
let pqEmpty (PQ h) = Heap.heapEmpty h
let enPQ v (PQ h) = PQ(Heap.insHeap v h)
let frontPQ (PQ h) = Heap.findHeap h
let dePQ (PQ h) = PQ(Heap.delHeap h)

open Heap.MyHeap
module MyPriorityQueue =
  type PQ<'a when 'a: comparison> = PQ of MyHeap.Heap<'a>
  let empty = PQ MyHeap.empty
  let isEmpty (PQ h) = MyHeap.isEmpty h
  let enqueue v (PQ h) = PQ(MyHeap.insert v h)
  let peak (PQ h) = MyHeap.find h
  let dequeue (PQ h) = PQ(MyHeap.delete h)
