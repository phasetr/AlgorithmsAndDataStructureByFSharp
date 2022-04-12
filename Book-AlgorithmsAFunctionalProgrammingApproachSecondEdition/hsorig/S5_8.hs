module S5_8 where

import Heap (Heap(..),emptyHeap,insHeap,merge)

fig5_5a = insHeap 6 (insHeap 1(insHeap 4 (insHeap 8 emptyHeap)))
fig5_5b = insHeap 7 (insHeap 5 emptyHeap)
main = print $ fig5_5a == HP 1 2 (HP 4 1 (HP 8 1 EmptyHP EmptyHP) EmptyHP) (HP 6 1 EmptyHP EmptyHP)
  && fig5_5b == HP 5 1 (HP 7 1 EmptyHP EmptyHP) EmptyHP
  && merge fig5_5a fig5_5b == HP 1 2 (HP 5 2 (HP 7 1 EmptyHP EmptyHP) (HP 6 1 EmptyHP EmptyHP)) (HP 4 1 (HP 8 1 EmptyHP EmptyHP) EmptyHP)
  && insHeap 3 emptyHeap == HP 3 1 EmptyHP EmptyHP

{- examples of calls and results
S5_8> insHeap 3 emptyHeap
HP 3 1 EmptyHP EmptyHP
S5_8> insHeap 1 $$
HP 1 1 (HP 3 1 EmptyHP EmptyHP) EmptyHP
S5_8> insHeap 4 $$
HP 1 2 (HP 3 1 EmptyHP EmptyHP) (HP 4 1 EmptyHP EmptyHP)
S5_8> insHeap 1 $$
HP 1 1 (HP 1 2 (HP 3 1 EmptyHP EmptyHP) (HP 4 1 EmptyHP EmptyHP)) EmptyHP
S5_8> insHeap 5 $$
HP 1 2 (HP 1 2 (HP 3 1 EmptyHP EmptyHP) (HP 4 1 EmptyHP EmptyHP)) (HP 5 1 EmptyHP EmptyHP)
S5_8> insHeap 9 $$
HP 1 2 (HP 1 2 (HP 3 1 EmptyHP EmptyHP) (HP 4 1 EmptyHP EmptyHP)) (HP 5 1 (HP 9 1 EmptyHP EmptyHP) EmptyHP)
S5_8> insHeap 2 $$
HP 1 2 (HP 1 2 (HP 3 1 EmptyHP EmptyHP) (HP 4 1 EmptyHP EmptyHP)) (HP 2 1 (HP 5 1 (HP 9 1 EmptyHP EmptyHP) EmptyHP) EmptyHP)
S5_8> insHeap 6 $$
HP 1 3 (HP 1 2 (HP 3 1 EmptyHP EmptyHP) (HP 4 1 EmptyHP EmptyHP)) (HP 2 2 (HP 5 1 (HP 9 1 EmptyHP EmptyHP) EmptyHP) (HP 6 1 EmptyHP EmptyHP))
S5_8> delHeap $$
HP 1 2 (HP 2 2 (HP 5 1 (HP 9 1 EmptyHP EmptyHP) EmptyHP) (HP 4 1 (HP 6 1 EmptyHP EmptyHP) EmptyHP)) (HP 3 1 EmptyHP EmptyHP)
S5_8> delHeap $$
HP 2 2 (HP 5 1 (HP 9 1 EmptyHP EmptyHP) EmptyHP) (HP 3 1 (HP 4 1 (HP 6 1 EmptyHP EmptyHP) EmptyHP) EmptyHP)
S5_8> delHeap $$
HP 3 2 (HP 4 1 (HP 6 1 EmptyHP EmptyHP) EmptyHP) (HP 5 1 (HP 9 1 EmptyHP EmptyHP) EmptyHP)
S5_8> delHeap $$
HP 4 2 (HP 6 1 EmptyHP EmptyHP) (HP 5 1 (HP 9 1 EmptyHP EmptyHP) EmptyHP)
S5_8> delHeap $$
HP 5 2 (HP 9 1 EmptyHP EmptyHP) (HP 6 1 EmptyHP EmptyHP)
S5_8> delHeap $$
HP 6 1 (HP 9 1 EmptyHP EmptyHP) EmptyHP
S5_8> delHeap $$
HP 9 1 EmptyHP EmptyHP
S5_8> delHeap $$
EmptyHP
-}
