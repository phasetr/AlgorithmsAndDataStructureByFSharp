{-
https://atcoder.jp/contests/abc158/submissions/11747270
-}
main :: IO ()
main = do
  s <- getLine
  q <- getLine
  ls <- lines <$> getContents
  putStrLn $ solve s "" $ map words ls

solve :: String -> String -> [[String]] -> String
solve s e []     = s ++ reverse e
solve s e (l:ls)
  | head l == "1" = solve e s ls
  | l !! 1 == "1" = solve (l!!2 ++ s) e ls
  | otherwise     = solve s (l!!2 ++ e) ls
