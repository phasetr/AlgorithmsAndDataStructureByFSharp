-- https://atcoder.jp/contests/abc085/submissions/15211452
{-# OPTIONS_GHC -O2 #-}
import qualified Data.ByteString.Char8             as C
import qualified Data.Vector.Algorithms.Intro      as Intro
import qualified Data.Vector.Unboxed               as U
-- #define MOD 1000000007

main :: IO ()
main = do
  [n, h] <- map read.words <$> getLine
  es <- U.unfoldrN n (runParser $ (,) <$> int <*> int) <$> C.getContents
  print $ solve n h es

solve :: Int -> Int -> U.Vector (Int, Int) -> Int
solve n h (U.unzip -> (as, bs))
  | sumB' < h = U.length bs' + div (h - sumB' + (maxA - 1)) maxA
  | otherwise = U.length . U.takeWhile (<h) $ U.scanl' (+) 0 bs'
  where
    maxA = U.maximum as
    bs' = U.modify (Intro.sortBy (flip compare)) $ U.filter (>maxA) bs
    sumB' = U.sum bs'
