{-
https://atcoder.jp/contests/agc022/submissions/13267643
-}
main :: IO ()
main = do
  s <- getLine
  let alphabet = "abcdefghijklmnopqrstuvwxyz"
      n = length s
      ans | n < 26 = s ++ g s alphabet
          | null s' = "-1"
          | otherwise = init s' ++ g s' (dropWhile (<= last s') alphabet)
        where s' = take (n - f (reverse s)) s
  putStrLn ans

f :: (Num p, Ord a) => [a] -> p
f [] = 0
f [a] = 1
f (a:b:as) | a < b = 1 + f (b:as)
           | otherwise = 1

g :: (Foldable t, Eq a) => t a -> [a] -> [a]
g s a = [head (dropWhile (`elem` s) a)]
