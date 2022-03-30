-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_6_D/review/2210379/aimy/Haskell
main :: IO ()
main = interact
  $ unlines . map show . solve . read' . lines where
  read' (nm:xs) = (map (map read . words) mat, map read vec) where
    n = read $ head $ words nm
    (mat,vec) = splitAt n xs
  read' _ = error "undefined"

solve (mat,vec) = map (sum . zipWith (*) vec) mat
