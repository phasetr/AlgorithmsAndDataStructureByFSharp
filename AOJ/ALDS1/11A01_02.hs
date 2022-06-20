-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_11_A/review/1686311/satoshi3/Haskell
solve :: [Int] -> Int -> Int -> String
solve all@(x:xs) n count
  | count > n  = []
  | x == count = '1' : ' ' : solve xs n (count + 1)
  | otherwise  = '0' : ' ' : solve all n (count + 1)
solve _ _ _ = error "not come here"

ctr :: Int -> [[Int]] -> [String]
ctr n (x:xs)
  | null xs = []
  | otherwise = solve (x ++ [-1]) n 1 : ctr n xs
ctr _ _ = error "not come here"

main :: IO ()
main = do
  n <- readLn
  getContents >>= (mapM_ (putStrLn . init) . ctr n . (++[[1]]) . map (map read . drop 2 . words) . lines)
