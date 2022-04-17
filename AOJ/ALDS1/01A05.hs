-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_1_A/review/2010888/earlgrey/Haskell
pl :: [Int] -> IO ()
pl xs = putStrLn $ unwords $ map show xs

insertion :: Int -> [Int] -> [Int]
insertion i xs = [x | x <- p, x <= v] ++ [v] ++ [x | x <- p, v < x] ++ drop (i + 1) xs
    where
        p = take i xs
        v = xs !! i

solve :: Int -> [Int] -> [[Int]]
solve n xs = foldl (\l i -> insertion i (head l) : l) [xs] [1..n-1]

main :: IO ()
main = do
  n  <- readLn
  xs <- fmap (map read . words) getLine
  mapM_ pl $ reverse $ solve n xs
