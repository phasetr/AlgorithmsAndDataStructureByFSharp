-- https://atcoder.jp/contests/tessoku-book/submissions/35454088
import Control.Monad ( replicateM )
import Data.Array ( elems, listArray, (!), accumArray )

main :: IO ()
main = do
  [n,k] <- getLnInts
  abs <- replicateM n getLnInts
  let ans = tba42 n k abs
  print ans

getLnInts :: IO [Int]
getLnInts = map read . words <$> getLine

tba42 :: Int -> Int -> [[Int]] -> Int
tba42 n k abs = ans where
  arr = accumArray (+) 0 ((1,1),(100,100)) [((a,b),1) | (a:b:_) <- abs]
  sarr = listArray ((0,0),(100,100)) $ concat $
         scanl (zipWith (+)) (replicate 101 0) $
         map (scanl (+) 0) $ chunksOf 100 $ elems arr
  ans = maximum
    [ sarr ! (i+k,j+k) - sarr ! (i+k,pred j) - sarr ! (pred i,j+k) + sarr ! (pred i, pred j)
    | i <- [1..100-k], j <- [1..100-k]]

chunksOf :: Int -> [a] -> [[a]]
chunksOf _ [] = []
chunksOf n xs = let (as,bs) = splitAt n xs in as : chunksOf n bs
