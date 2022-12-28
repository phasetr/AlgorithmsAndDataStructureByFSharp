-- https://atcoder.jp/contests/tessoku-book/submissions/37383703
{-# LANGUAGE BangPatterns #-}
import Control.Monad ( join, replicateM_ )
import qualified Data.ByteString.Char8 as C
import Data.List ( unfoldr )
import Data.Vector.Generic ((!))
import qualified Data.Vector.Unboxed as U

main :: IO ()
main = join $ sub <$> readLn <*> get <*> readLn

sub :: Int -> [Int] -> Int -> IO ()
sub n as d = replicateM_ d (get >>= print . sol b c) where
  a = U.fromListN n as
  b = U.scanl max 0 a
  c = U.scanr max 0 a

get :: IO [Int]
get = unfoldr (C.readInt . C.dropWhile (<'+')) <$> C.getLine

sol !b !c [l,r] = max (b!(l-1)) (c!r)
sol _ _ _ = error "not come here"
