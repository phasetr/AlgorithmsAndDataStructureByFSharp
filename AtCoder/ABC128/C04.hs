-- https://atcoder.jp/contests/abc128/submissions/5656194
main :: IO ()
main = interact
  $ show . f . map (map read . words) . lines
f :: [[Int]] -> Int
f ([n,m]:z) =
  sum [1 | s <- mapM (:[0]) [1..n],
        and $ zipWith
        (\(k:l) p ->
            even $ p+sum [1 | x <- l, x `elem` s])
        z $ z!!m]
f _ = error "undefined"
