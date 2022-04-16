-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_10_C/review/1693328/satoshi3/Haskell
solve :: [[Float]] -> [Float]
solve ((0 : _) : _) = []
solve ((n : _) : is : xs) = sqrt (sum [(i - sum is / n)^2 | i <- is] / n) : solve xs
solve _ = undefined

main :: IO ()
main = getContents >>= mapM_ print . solve . map (map read . words) . lines
