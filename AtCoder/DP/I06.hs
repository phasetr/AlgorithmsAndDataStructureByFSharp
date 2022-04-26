-- https://atcoder.jp/contests/dp/submissions/19689869
import Data.List ( unfoldr )
import Data.Maybe ( listToMaybe )
import qualified Data.Vector.Unboxed as U
import Data.Vector.Unboxed ((!))
import Numeric ( readFloat )

main :: IO ()
main = sol <$> readLn <*> get >>= print

get :: IO [Double]
get = unfoldr (listToMaybe . readFloat . dropWhile (<'+')) <$> getLine

sol :: Int -> [Double] -> Double
sol n ps = U.sum . U.take (1+n `div` 2) $ f n where
  p = U.fromListN (n+1) (0:ps)
  q = U.map (1 -) p
  f 0 = U.singleton (1 :: Double)
  f i = U.zipWith (+) l r where
    l = U.map (*(p!i)) (f (i-1)) `U.snoc` 0
    r = 0 `U.cons` U.map (*(q!i)) (f (i-1))
