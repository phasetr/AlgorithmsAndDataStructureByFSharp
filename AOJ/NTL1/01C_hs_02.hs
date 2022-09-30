-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/NTL_1_C/review/2121887/pedal/Haskell
import Data.List(foldl1')

main :: IO ()
main = do
  s' <- getContents
  print $ foldl1' lcm $ map read $ tail $ words s'
