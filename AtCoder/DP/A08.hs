-- https://atcoder.jp/contests/dp/submissions/22184957
import qualified Data.ByteString.Char8 as C
import qualified Data.Vector.Unboxed as U
import Data.Vector.Unboxed ((!))

main :: IO ()
main = sub =<< get 1

sub :: U.Vector Int -> IO ()
sub u = get (u!0) >>= print . sol (u!0)

get :: Int -> IO (U.Vector Int)
get n = U.unfoldrN n (C.readInt . C.dropWhile (<'+')) <$> C.getLine

sol :: (Num a, Ord a, U.Unbox a) => Int -> U.Vector a -> a
sol n v = dp!(n-1) where
  dp = U.constructN n f
  f u | i==0      = 0
      | otherwise = U.minimum . U.map (\(d,h) -> d+abs (h-v!i)) . U.drop (i-2) $ U.zip u v
    where i = U.length u
