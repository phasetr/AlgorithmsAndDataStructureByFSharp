-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_10_B/review/3373049/showzaemon/Haskell
import qualified Data.ByteString.Char8 as B
import Data.Array ( listArray, (!), (//), accumArray )
import Data.Maybe ( fromJust )
import Control.Monad ( replicateM )

main :: IO()
main = do
  n <- fmap (fst . fromJust . B.readInt) B.getLine
  l <- replicateM n (fmap (map (fst . fromJust . B.readInt) . B.words) B.getLine)
  let l' = if n > 0
           then head (head l) : foldr (\[x, y] b-> y:b) [] l
           else []
  if n < 2 then print 0 else print $ solve n l'

solve :: Int -> [Int] -> Int
solve m ls = iter 1 initialTable where
  iter n tbl
    | n < m = iter (n+1) (next n tbl)
    | otherwise = tbl!(1, m)

  initialTable = accumArray (+) 0 ((1,1), (m, m)) []

  matrixSizeVector = listArray (0, m) ls
  product3 x y z = (matrixSizeVector!x) * (matrixSizeVector!y) * (matrixSizeVector!z)

  next n tbl = iter 1 [] where
    iter i ac
      | j <= m = iter (i+1) (updateAssociation:ac)
      | otherwise = tbl // ac where
          j = i + n
          updateAssociation = iter 0 maxBound where
            iter k minProducts
              | i + k < j = iter (k+1) (min minProducts products)
              | otherwise = ((i, j), minProducts) where
                  products = tbl!(i, i+k) + tbl!(i+k+1, j) + product3 (i-1) (i+k) j

test = do
  print $ solve 6 [30,35,15,5,10,20,25] == 15125
