-- https://atcoder.jp/contests/code-festival-2016-qualb/submissions/13623396
main = do
  [n,a,b] <- map read . words <$> getLine
  s <- getLine
  mapM putStrLn (solve (a,b) s)

solve :: (Int,Int) -> [Char] -> [String]
solve _ [] = []
solve (a,b) ('a':ss)
  | a+b > 0 = "Yes" : solve (a-1,b) ss
solve (a,b) ('b':ss)
  | a+b > 0 && b > 0 = "Yes" : solve (a,b-1) ss
solve (a,b) (_:s) = "No" : solve (a,b) s
