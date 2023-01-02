-- https://atcoder.jp/contests/tessoku-book/submissions/35367734
import Control.Monad ( replicateM_ )
import Data.List ()

main :: IO ()
main = do
  q <- readLn
  replicateM_ q $ do
    x <- readLn
    putStrLn $ if isPrime x then "Yes" else "No"

-- 簡易版
primes :: [Integer]
primes = 2 : 3 : [p | x <- [5, 11..], p <- [x, x+2], isPrime p]

isPrime :: Integer -> Bool
isPrime x = all ((0 /=) . mod x) $ takeWhile ((x >=) . (^ 2)) primes
