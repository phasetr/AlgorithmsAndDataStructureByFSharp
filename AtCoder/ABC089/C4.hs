{-
https://atcoder.jp/contests/abc089/submissions/12934109
-}
import Control.Monad (replicateM)
import Data.List (group,sort)
main :: IO ()
main = do
  n <- readLn
  xs <- replicateM n getLine
  print $ solve xs

--solve :: [String] -> Int
solve xs = sum [(fs !! i) * (fs !! j) * (fs !! k) |
                i <- [0..l-3],
                j <- [i+1..l-2],
                k <- [j+1..l-1]] where
  fs = map length . group . sort . filter (`elem` "MARCH") . map head $ xs
  l = length fs
