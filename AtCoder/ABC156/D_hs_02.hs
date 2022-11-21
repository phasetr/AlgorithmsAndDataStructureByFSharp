-- https://atcoder.jp/contests/abc156/submissions/10295676
main :: IO ()
main = do
  [n, a, b] <- map read.words <$> getLine
  print $ solve n a b

solve :: Int -> Int -> Int -> Int
solve n a b = (2 ^% n) -% comb n a -% comb n b -% 1 where
  mo = 10^9 + 7 :: Int
  a ^% b
    | b < 0 = 0
    | b == 0 = 1
    | otherwise = f a b
    where
      f a b
        | even b = f (a *% a) (quot b 2)
        | b == 1 = a
        | otherwise = g (a *% a) (quot b 2) a
      g a b c
        | even b = g (a *% a) (quot b 2) c
        | b == 1 = a *% c
        | otherwise = g (a *% a) (quot b 2) (a *% c)
  a *% b = rem (a * b) mo
  a /% b = a *% (b ^% (mo - 2))
  comb a b = foldl (*%) 1 [a-b+1..a] /% foldl (*%) 1 [1..b]
  a -% b = rem (mo + a - b) mo
