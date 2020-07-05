#load "Heap.fsx"
// Rabhi-Lapalme, P.107
open Heap

module PriorityQueueByHeap =
    type PQueue<'a when 'a: comparison> = PQ of Heap.Heap<'a>
    let emptyPQ = PQ Heap.emptyHeap
    let pqEmpty (PQ h) = Heap.heapEmpty h
    let enPQ v (PQ h) = PQ(Heap.insHeap v h)
    let frontPQ (PQ h) = Heap.findHeap h
    let dePQ (PQ h) = PQ(Heap.delHeap h)

open PriorityQueueByHeap

emptyPQ |> printfn "%A"
