-- https://atcoder.jp/contests/dp/submissions/19690763
{-# LANGUAGE BangPatterns #-}
import Data.Bool ( bool )
import qualified Data.Vector.Unboxed as U
import Data.Vector.Unboxed ((!))

main :: IO ()
main = readLn >>= \n -> get n >>= print . solve n

get :: (U.Unbox a, Read a) => Int -> IO (U.Vector a)
get t = U.fromListN t . fmap read . words <$> getLine

solve :: Int -> U.Vector Double -> Double
solve n = U.sum . U.take (1+n `div` 2) . U.foldl' f (U.singleton (1 :: Double)) where
  f !u !p = U.generate (i+1) g where
    i = U.length u
    g j = p*bool 0 (u!j) (j<i) + (1-p)*bool 0 (u!(j-1)) (j>0)
