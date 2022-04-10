-- https://atcoder.jp/contests/dp/submissions/22184897
import qualified Data.ByteString.Char8 as C
import qualified Data.Vector.Unboxed as U
import Data.Vector.Unboxed ((!))

main = sub =<< get 2
sub u = get (u!0) >>= print . solve (u!0) (u!1)
get n = U.unfoldrN n (C.readInt . C.dropWhile (<'+')) <$> C.getLine

solve n k v = dp!(n-1) where
  dp = U.constructN n f
  f u
    | i==0      = 0
    | otherwise = U.minimum . U.map (\(d,h) -> d+abs (h-v!i)) . U.drop (i-k) $ U.zip u v
    where
    i = U.length u
