{-
https://atcoder.jp/contests/agc028/submissions/3401713
-}
f :: Eq a => [Int] -> [a] -> [a] -> Int
f [n, m] = judge where
  sstep = div n $ gcd n m
  tstep = div m $ gcd n m
  judge [] [] = lcm n m
  judge s' t' = if head s' == head t' then judge (drop sstep s') (drop tstep t') else (-1)
f _ = error "not come here"

main :: IO ()
main = f <$> (map read . words <$> getLine) <*> getLine <*> getLine >>= print
