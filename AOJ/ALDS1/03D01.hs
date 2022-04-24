-- https://onlinejudge.u-aizu.ac.jp/problems/ALDS1_3_D
main :: IO ()
main = getLine >>= putStrLn . solve

solve :: String -> String
solve s = show (sum areas) ++ "\n" ++ unwords (map show (length areas : areas))
  where areas = help [] [] (zip [0..] s)

help :: [(Int, Char)] -> [(Int, Int)] -> [(Int, Char)] -> [Int]
help _ ps [] = map snd (reverse ps)
help ds ps (x@(n,'\\'):xs) = help (x:ds) ps xs
help [] ps (x@(n,'/'):xs) = help [] ps xs
help ((m,_):ds) ps (x@(n, '/'):xs) = help ds (newp:pr) xs where
  (pl,pr) = span ((>= m) . fst) ps
  newp = (n,(n-m) + sum (map snd pl))
help ds ps (x:xs) = help ds ps xs

test :: IO ()
test = do
  print $ help [] [] (zip [0..] "\\\\//") == [4]
