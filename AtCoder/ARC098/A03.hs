{-
https://atcoder.jp/contests/arc098/submissions/6244176
-}
dirToInt :: Char -> Char -> Int
dirToInt ch d
  | ch == d = 1
  | otherwise = 0

minimize :: String -> Int
minimize xs = pred $ minimum $ zipWith (+) ls rs where
  ls = scanl1 (+) $ map (dirToInt 'W') xs
  rs = scanr1 (+) $ map (dirToInt 'E') xs

main :: IO ()
main = getLine >> getLine >>= print . minimize
