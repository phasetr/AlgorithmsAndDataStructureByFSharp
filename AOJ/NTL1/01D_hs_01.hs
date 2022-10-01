-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/NTL_1_D/review/3118805/little_Haskeller/Haskell
import Data.List ( group )

factorize :: Integral a => a -> [(a, Int)]
factorize n = [(x, length xs) | xs@(x : _) <- group $ factorize' n]

factorize' :: Integral a => a -> [a]
factorize' 1 = []
factorize' n = loop n divs where
  divs = 2 : 3 : concat [[x, x + 2] | x <- [5, 11 ..]]
  loop n ps@(p : ps')
    | p * p > n    = [n]
    | rem n p == 0 = p : loop (div n p) ps
    | otherwise    = loop n ps'
  loop _ _ = error "not come here"

phi :: Integral a => a -> a
phi n = product [p^(i - 1) * (p - 1) | (p, i) <- factorize n]

main :: IO ()
main = do
  n <- getLine
  print $ phi (read n)
