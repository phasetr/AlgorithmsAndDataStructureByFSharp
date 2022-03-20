{-
https://atcoder.jp/contests/arc098/submissions/11046022
-}
main :: IO ()
main = do
  getLine
  s <- getLine::IO[Char]
  print $ solve s

solve :: String -> Int
solve s = minimum $ zipWith g s cumulative
  where
    f (w,e) v = if v == 'W' then (w+1,e) else (w,e+1)
    g v (w,e) = if v == 'W' then result else result - 1
      where result = w + (snd vectorAll - e)
    cumulative = scanl f (0,0) s
    vectorAll = last cumulative
