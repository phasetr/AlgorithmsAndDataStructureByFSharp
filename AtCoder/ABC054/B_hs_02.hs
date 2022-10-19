-- https://atcoder.jp/contests/abc054/submissions/3141540
import Control.Monad ( replicateM )
match :: Eq a => [[a]] -> [[a]] -> Int -> Int -> Bool
match a b i j = let m = length b in b == (map (take m . drop j) . take m . drop i) a
main :: IO ()
main = do
  [n, m] <- map read . words <$> getLine
  a <- replicateM n getLine
  b <- replicateM m getLine
  putStrLn (if or [match a b i j | i <- [0..n-m], j <- [0..n-m]] then "Yes" else "No")
