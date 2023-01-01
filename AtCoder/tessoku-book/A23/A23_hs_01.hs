-- https://atcoder.jp/contests/tessoku-book/submissions/35263155
import Control.Monad ( replicateM )
import qualified Data.ByteString.Char8 as BS
import Data.Array.Unboxed
    ( (!), accumArray, assocs, listArray, UArray )
import Data.Bits ( Bits((.|.)) )
import Data.Char ( isSpace )
import Data.Functor ( (<&>) )
import Data.List ( foldl', unfoldr )

tba23 :: Int -> Int -> [[Int]] -> Int
tba23 n m ass = if ans >= tooBig then -1 else ans where
  ub = 2^n - 1
  initial :: UArray Int Int
  initial = listArray (0,ub) $ 0 : replicate ub tooBig
  final = foldl' step initial ass
  step :: UArray Int Int -> [Int] -> UArray Int Int
  step arr as =
    accumArray min tooBig (0,ub)
    [z | pc@(p,c) <- assocs arr, z <- [pc, (p .|. q, succ c)]]
    where q = oi2n as
  ans = final ! ub

oi2n :: [Int] -> Int
oi2n = foldl (\a d -> a * 2 + d) 0

tooBig :: Int
tooBig = div maxBound 2

main :: IO ()
main = do
  [n,m] <- bsGetLnInts
  ass <- replicateM m bsGetLnInts
  let ans = tba23 n m ass
  print ans

bsGetLnInts :: IO [Int]
bsGetLnInts = BS.getLine <&> unfoldr (BS.readInt . BS.dropWhile isSpace)
