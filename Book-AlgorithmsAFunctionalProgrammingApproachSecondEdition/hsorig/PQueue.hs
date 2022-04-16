module PQueue(PQueue,emptyPQ,pqEmpty,enPQ,dePQ,frontPQ) where
import Heap (Heap,emptyHeap,heapEmpty,findHeap,insHeap,delHeap)

emptyPQ :: (Eq a,Ord a) => PQueue a
pqEmpty :: (Eq a,Ord a) => PQueue a -> Bool
enPQ    :: (Eq a,Ord a) => a -> PQueue a -> PQueue a
dePQ    :: (Eq a,Ord a) => PQueue a -> PQueue a
frontPQ :: (Eq a,Ord a) => PQueue a -> a

newtype PQueue a = PQ (Heap a) deriving Show

emptyPQ = PQ emptyHeap
pqEmpty (PQ h) = heapEmpty h
enPQ v (PQ h) = PQ (insHeap v h)
frontPQ (PQ h) = findHeap h
dePQ (PQ h) = PQ (delHeap h)
