-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_10_A/review/1442784/lrmystp/Haskell
main :: IO ()
main = readLn >>= \n -> print $ fibs !! n

fibs :: [Integer]
fibs = 1 : 1 : zipWith (+) fibs (tail fibs)
