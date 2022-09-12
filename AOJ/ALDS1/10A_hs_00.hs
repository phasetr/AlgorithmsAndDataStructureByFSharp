-- https://onlinejudge.u-aizu.ac.jp/problems/ALDS1_10_A
import qualified Data.Vector as V
main :: IO ()
main = readLn >>= print . fib

fib :: Int -> Integer
fib n = fibv V.! n where
  fibv = V.fromList [f x | x <- [0..n]]
  f 0 = 1
  f 1 = 1
  f n = fibv V.! (n-2) + fibv V.! (n-1)

test :: IO ()
test = print $ fib 3 == 3
