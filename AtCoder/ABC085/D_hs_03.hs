-- https://atcoder.jp/contests/abc085/submissions/9331476
import Control.Monad ( replicateM )
import Data.List ( sort )

readInts :: IO [Int]
readInts = map read . words <$> getLine

f :: Integral a => a -> [[a]] -> a
f h ds = g 0 h th where
  sw = maximum $ map head ds
  th = sort $ filter (<negate sw) $ map (negate . head . tail) ds
  g t r [] = t +div (r + sw - 1) sw
  g t r (x:xs)
    | r+x<=0 = t+1
    | otherwise = g (t+1) (r+x) xs

main :: IO ()
main = readInts >>= \[n, h] -> replicateM n readInts >>= print . f h
