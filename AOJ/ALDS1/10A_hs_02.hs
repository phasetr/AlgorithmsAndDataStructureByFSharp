-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_10_A/review/2912611/lvs7k/Haskell
import qualified Data.ByteString.Char8 as B
import Data.Array.IArray ( Array, (!), listArray )

fib :: Int -> Int
fib n = go n where
  memo :: Array Int Int
  memo = listArray (0, n) $ fmap go [0 .. n]
  go 0 = 1
  go 1 = 1
  go k = memo ! (k - 1) + memo ! (k - 2)

main :: IO ()
main = readLn >>= print . fib
