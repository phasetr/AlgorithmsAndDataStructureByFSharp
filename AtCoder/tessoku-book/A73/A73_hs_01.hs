-- https://atcoder.jp/contests/tessoku-book/submissions/35694978
import Control.Monad ( replicateM, forM_ )
import Data.Maybe ( fromJust )
import qualified Data.ByteString.Char8 as BS
import qualified Data.Vector.Unboxed as VU
import qualified Data.Vector.Unboxed.Mutable as VUM
import qualified Data.Vector as V
import qualified Data.Vector.Mutable as VM

data Heap a = Empty | Heap !Int !a !(Heap a) !(Heap a) deriving Show

empty :: Heap a
empty = Empty

singleton :: a -> Heap a
singleton x = Heap 1 x Empty Empty

--併合
merge :: Ord a => Heap a -> Heap a -> Heap a
merge h Empty = h
merge Empty h = h
merge h1@(Heap _ x l1 r1) h2@(Heap _ y l2 r2)
  | x < y     = makeHeap x l1 (merge r1 h2)
  | otherwise = makeHeap y l2 (merge r2 h1)

rank :: Heap a -> Int
rank Empty = 0
rank (Heap r _ _ _) = r

makeHeap :: a -> Heap a -> Heap a -> Heap a
makeHeap x a b
  | ra >= rb  = Heap (rb + 1) x a b
  | otherwise = Heap (ra + 1) x b a
  where
    ra = rank a
    rb = rank b

--挿入
heapInsert :: Ord a => Heap a -> a -> Heap a
heapInsert h x = merge (singleton x) h

--リストから
heapFromList :: Ord a => [a] -> Heap a
heapFromList = foldl heapInsert Empty

--リストへ
heapToList :: Ord a => Heap a -> [a]
heapToList h | isEmpty h = []
             | otherwise = let (x, h') = deleteMin h in x : heapToList h'

--最小値の取り出し（削除）
deleteMin :: Ord a => Heap a -> (a, Heap a)
deleteMin Empty = error "Empty Heap"
deleteMin (Heap _ x a b) = (x, merge a b)

--最小値を見る（削除しない）
findMin :: Heap a -> a
findMin Empty = error "Empty Heap"
findMin (Heap _ x _ _) = x

--空か
isEmpty :: Heap a -> Bool
isEmpty Empty = True
isEmpty _     = False

readInt = fst . fromJust . BS.readInt
readIntList = map readInt . BS.words
getInt = readInt <$> BS.getLine
getIntList = readIntList <$> BS.getLine

main :: IO ()
main = do
  [n, m] <- getIntList
  abc <- replicateM m $ do
    [a, b, c, d] <- getIntList
    return (a-1, b-1, c*10000 - d)

  let edge = V.create $ do
        vec <- VM.replicate n []
        forM_ abc $ \(a, b, c) -> do
          VM.modify vec ((c, a) :) b
          VM.modify vec ((c, b) :) a
        return vec

  let dist = VU.create $do
        dvec <- VUM.replicate n (9000000000 :: Int)
        visited <- VUM.replicate n False
        VUM.write dvec 0 0
        VUM.write visited 0 True
        let dijkstra Empty = return ()
            dijkstra h = do
              let ((c, v), h') = deleteMin h
              vtd <- VUM.read visited v
              if vtd
              then dijkstra h'
              else do
                VUM.write visited v True
                VUM.modify dvec (min c) v
                m <- VUM.read dvec v
                let next = edge V.! v
                let f fh (fx, fv) = heapInsert fh (fx + m, fv)
                let h'' = foldl f h' next
                dijkstra h''
        dijkstra $ heapFromList (edge V.! 0)
        return dvec
  let d = dist VU.! (n-1)
  let x = (d + 9999) `div` 10000
      y = 10000 - (d `mod` 10000)
  putStrLn $ show x ++ " " ++ show y
