-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_7_D/review/2211449/aimy/Haskell
import Data.List (transpose)
main :: IO ()
main = interact
  $ unlines . show' . solve . read' . lines
  where
    read' xs = let ([n,m,l]:xs') = map (map read . words) xs in splitAt n xs'
    show' = map (unwords . map show)
solve :: ([[Int]], [[Int]]) -> [[Int]]
solve (matA, matB) =
  map (\v -> map (sum . zipWith (*) v) (transpose matB)) matA
