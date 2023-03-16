-- https://atcoder.jp/contests/tessoku-book/submissions/36193887
import Control.Monad
import qualified Data.ByteString.Char8 as BS
import Data.Char
import Data.Functor
import Data.List

import qualified Data.Heap as H
import Control.Monad.ST
import Data.Array.Unboxed
import Data.Array.ST

main = do
  [n,m] <- bsGetLnInts
  abcs <- replicateM m bsGetLnInts
  let ans = tbc14 n m abcs
  print ans

bsGetLnInts :: IO [Int]
bsGetLnInts = BS.getLine <&> unfoldr (BS.readInt . BS.dropWhile isSpace)

tbc14 :: Int -> Int -> [[Int]] -> Int
tbc14 n m abcs = 2 + length [() | k <- [2 .. pred n], d1n == d1 ! k + dN ! k] where
  d1 = dijkstraA n (ga !) 1
  dN = dijkstraA n (ga !) n
  d1n = d1 ! n
  ga :: Array Int [(Int,Int)]
  ga = accumArray (flip (:)) [] (1,n)
       [(i,(j,c)) | (a:b:c:_) <- abcs, (i,j) <- [(a,b),(b,a)]]

dijkstraA :: Int                           -- 頂点数
          -> (Int -> [(Int,Int)])          -- 隣接頂点とその辺の重み、グラフの情報
          -> Int                           -- 開始点
          -> UArray Int Int  -- 最短経路の重み
dijkstraA n graph start = runSTUArray action where
  action :: ST s (STUArray s Int Int)
  action = do
    dist <- newArray (1,n) maxBound
    writeArray dist start 0
    let queue = H.singleton (H.Entry 0 start)
    loop dist queue
    return dist
  loop :: STUArray s Int Int -> H.Heap (H.Entry Int Int) -> ST s ()
  loop _ queue
    | H.null queue = return ()
  loop dist queue = do
    let Just (H.Entry cost u, queue1) = H.uncons queue
    du <- readArray dist u
    if du < cost then loop dist queue1 else do
      vds <- forM (graph u) (\(v, len) -> do
        let d1 = du + len
        dv <- readArray dist v
        if d1 >= dv then return (H.Entry (-1) (-1)) else do
          writeArray dist v d1
          return (H.Entry d1 v)
        )
      let queue2 = H.union queue1 $ H.fromList [e | e@(H.Entry p _) <- vds, p /= -1]
      loop dist queue2
