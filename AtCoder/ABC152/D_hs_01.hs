-- https://atcoder.jp/contests/abc152/submissions/18700507
import Data.Char ( digitToInt )
import qualified Data.IntMap as IM
main :: IO ()
main = print . solve =<< readLn
solve :: (Show a2, Num a2, Enum a2, Num a1) => a2 -> a1
solve n = sum [g (i*10+j) * g (j*10+i) | i<-[1..9],j<-[1..9]] where
  m = IM.fromListWith (+) $ map (f . show) [1..n]
  g k = IM.findWithDefault 0 k m
f :: Num b => String -> (Int, b)
f i = (digitToInt (head i) * 10 + digitToInt (last i), 1)
