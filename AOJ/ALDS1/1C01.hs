-- http://judge.u-aizu.ac.jp/onlinejudge/description.jsp?id=ALDS1_1_C&lang=ja
-- http://judge.u-aizu.ac.jp/onlinejudge/review.jsp?rid=2609074#1
import Control.Monad (replicateM)
import Data.List

primes = takeWhile (<10000) $ primes' [2..]
  where
    primes' (p:l) = (p:primes' (filter ((/=0) . flip mod p) l))

isPrime x = elem x primes || all ((/=0) . mod x) primes

main =
  readLn >>=
    flip replicateM readLn >>=
      print . length . filter isPrime
