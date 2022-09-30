-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/NTL_1_B/review/2715314/marta1127/Haskell
main :: IO ()
main = do
  [m,n] <- fmap (map read.words) getLine
  print $ powMod 1000000007 m n

powMod :: Integer -> Integer -> Integer -> Integer
powMod _ _ 0 = 1
powMod p m n
  | even n =let x' = powMod p m (n `div` 2) in x'^2 `mod` p
  | odd n = let x' = powMod p m ((n-1) `div` 2) in m*x'^2 `mod` p
powMod _ _ _ = error "not come here"
