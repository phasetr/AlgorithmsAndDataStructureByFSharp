-- https://atcoder.jp/contests/dp/submissions/19766008
{-# LANGUAGE BangPatterns #-}
import Data.Bool ( bool )
import qualified Data.ByteString.Char8 as C
import Data.List ( unfoldr )
import qualified Data.Vector.Unboxed as U
import Data.Vector.Unboxed ((!))

main :: IO ()
main = get >>= \[n,k] -> getv n >>= putStrLn . solve k where
  get = unfoldr (C.readInt . C.dropWhile (<'+')) <$> C.getLine
  getv t = U.unfoldrN t (C.readInt . C.dropWhile (<'+')) <$> C.getLine

solve :: Int -> U.Vector Int -> [Char]
solve !k !a = bool "Second" "First" $ g!k where
  g = U.constructN (k+1) f :: U.Vector Bool
  f !v
    | U.null v  = False
    | otherwise = not . U.all ((v!) . (i -)) $ U.takeWhile (<=i) a
    where !i = U.length v
