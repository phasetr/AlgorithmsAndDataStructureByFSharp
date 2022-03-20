{-
https://atcoder.jp/contests/arc098/submissions/9847467
-}
main :: IO ()
main = do
  n <- readLn
  s <- getLine
  print $ solve n s

solve :: Int -> String -> Int
solve n s = minimum $ zipWith (+) l r where
  l = take n $ scanl (+) 0
    $ map (\c -> if c=='W' then 1 else 0) s
  r = reverse $ take n $ scanl (+) 0
    $ map (\c->if c=='E' then 1 else 0) $ reverse s

