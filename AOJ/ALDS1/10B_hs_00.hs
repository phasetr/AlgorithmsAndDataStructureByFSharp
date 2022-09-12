-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_10_B/review/3373049/showzaemon/Haskell
import Control.Monad ( replicateM )
import qualified Data.ByteString.Char8 as B
import qualified Data.Array as A
import Data.Maybe ( fromJust )
import qualified Data.Vector as V

main :: IO()
main = do
    n <- fmap (fst . fromJust . B.readInt) B.getLine
    xs <- replicateM n (fmap (map (fst . fromJust . B.readInt) . B.words) B.getLine)
    let xv = V.fromList $ head (head xs) : foldr (\[_,y] b -> y:b) [] xs
    if n < 2 then print 0 else print $ solve n xv

solve :: Int -> V.Vector Int -> Int
solve n xv = iter 1 (A.accumArray (+) 0 ((1,1), (n, n)) []) where
  iter m tbl
    | m < n = iter (m+1) (next m tbl)
    | otherwise = tbl A.! (1, n)

  prod x y z = (xv V.! x) * (xv V.! y) * (xv V.! z)

  next m tbl = iter 1 [] where
    iter i ac
      | i+m <= n = iter (i+1) (updateAssociation:ac)
      | otherwise = tbl A.// ac where
          updateAssociation = iter 0 maxBound where
            iter k minProducts
              | k<m = iter (k+1) (min minProducts products)
              | otherwise = ((i, i+m), minProducts)
              where products = tbl A.! (i,i+k) + tbl A.! (i+k+1,i+m) + prod (i-1) (i+k) (i+m)

test :: IO ()
test = do
  --let m = 3
  --print $ A.accumArray (+) 0 ((1,1), (m, m)) []
  --let xs = [[30,35],[35,15],[15,5],[5,10],[10,20],[20,25]]
  --let xv = V.fromList $ head (head xs) : foldr (\[_,y] b -> y:b) [] xs
  --print xv
  print $ solve 6 (V.fromList [30,35,15,5,10,20,25]) == 15125
