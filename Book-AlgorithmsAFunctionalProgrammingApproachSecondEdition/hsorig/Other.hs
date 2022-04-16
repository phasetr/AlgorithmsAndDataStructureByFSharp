module Other where
import BinomialHeap ( Heap(..), Tree(..), delHeap, emptyHeap, insHeap )

main :: IO ()
main = do
  print $ insHeap 3 emptyHeap == BH [Node 0 3 []]
  print $ insHeap 1 (insHeap 3 emptyHeap) == BH [Node 1 1 [Node 0 3 []]]
  print $ delHeap 1 (insHeap 1 (insHeap 3 emptyHeap)) == BH [Node 0 3 []]
  print $ delHeap 1 (insHeap 3 emptyHeap) == BH []
  print $ foldr insHeap emptyHeap (reverse [1,10,5,15,6]) == BH [Node 0 6 [],Node 2 1 [Node 1 5 [Node 0 15 []],Node 0 10 []]]
