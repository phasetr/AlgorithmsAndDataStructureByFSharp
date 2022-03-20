{-
https://atcoder.jp/contests/arc098/submissions/13163152
-}
main :: IO ()
main = do
  getLine
  s <- getLine
  print . minimum
    $ zipWith (\p q -> snd p + fst q)
    (scanl ew (0,0) s)
    (tail (scanr (flip ew) (0,0) s))

ew :: (Int, Int) -> Char -> (Int, Int)
ew (e,w) h | h == 'E' = (e+1,w)
           | otherwise = (e,w+1)
