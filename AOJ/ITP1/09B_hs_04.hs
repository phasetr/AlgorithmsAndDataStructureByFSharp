-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_9_B/review/2376812/napo/Haskell
main :: IO ()
main = getContents
  >>= putStr . unlines . map g . f
  . takeWhile (/="-").lines

f :: [String] -> [[String]]
f []       = []
f (s:n:xs) = (s : take (read n) xs) : f (drop (read n) xs)
f _ = undefined

g :: [String] -> String
g (x:xs) = foldl h x $ map read xs
g _ = undefined

h :: String -> Int -> String
h y n = drop n y ++ take n y
