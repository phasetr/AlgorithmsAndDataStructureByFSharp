{-
https://atcoder.jp/contests/agc031/submissions/9873232
-}
main :: IO ()
main=do
  getLine
  s <- getLine
  print $ solve s

solve :: String -> Int
solve s = pred $ foldl1 (\a b -> a*b `mod` (10^9+7))
  $ map (\c -> succ . length . filter (== c) $ s) ['a'..'z']
--  [succ $ length $ filter (==c) s | c <- ['a'..'z']]
