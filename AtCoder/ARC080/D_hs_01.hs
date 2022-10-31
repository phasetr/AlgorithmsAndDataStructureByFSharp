-- https://atcoder.jp/contests/abc069/submissions/1491629
-- AtCoder My Practice
-- author: Leonardone @ NEETSDKASU

main :: IO ()
main = putStrLn . unlines . map (unwords.map show) .  solve . map read . words =<< getContents

solve :: [Int] -> [[Int]]
solve (h:w:n:xs) = zs where
  ys = concat $ zipWith replicate xs [1..]
  zs = f ys 0
  f [] _ = []
  f ss i = vv : f ww (i+1) where
    (uu, ww) = splitAt w ss
    vv = if even i then uu else reverse uu
solve _ = error "not come here"
