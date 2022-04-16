-- http://judge.u-aizu.ac.jp/onlinejudge/description.jsp?id=ALDS1_1_C&lang=ja
-- http://judge.u-aizu.ac.jp/onlinejudge/review.jsp?rid=2609074#1
import Control.Monad (replicateM)

main :: IO ()
main = readLn >>= flip replicateM readLn >>= print . solve

solve :: [Integer] -> Int
solve = length . filter isPrime where
  isPrime x = elem x primes || all ((/=0) . mod x) primes where
    primes = takeWhile (<10000) $ primes' [2..] where
      primes' [] = []
      primes' (p:l) = p:primes' (filter ((/=0) . flip mod p) l)

test :: IO ()
test = print $ solve [6,2,3,4,5,6,7]
