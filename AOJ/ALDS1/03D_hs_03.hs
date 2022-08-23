-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_3_D/review/2871023/lvs7k/Haskell
solve :: [(Int, Char)] -> [(Int, Int)] -> [(Int, Char)] -> [Int]
solve _ ps [] = fmap snd (reverse ps)
solve ds ps (x@(n, '\\'):xs) = solve (x : ds) ps xs
solve [] ps (x@(n, '/'):xs) = solve [] ps xs
solve ((m, _):ds) ps (x@(n, '/'):xs) = solve ds (newp : pr) xs where
  (pl, pr) = span ((>= m) . fst) ps
  newp = (n, (n - m) + sum (fmap snd pl))
solve ds ps (x:xs) = solve ds ps xs

main :: IO ()
main = do
  xs <- getLine
  let areas = solve [] [] (zip [0 ..] xs)
  print $ sum areas
  putStrLn . unwords $ fmap show (length areas : areas)

