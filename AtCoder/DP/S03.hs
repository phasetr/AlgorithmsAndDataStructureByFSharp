-- https://atcoder.jp/contests/dp/submissions/21400892
import qualified Data.ByteString.Char8 as C
import Data.Char ( digitToInt )
import qualified Data.Vector as V
import qualified Data.Vector.Unboxed as U
import Data.Vector.Unboxed ((!))

main :: IO ()
main = solve <$> C.getLine <*> readLn >>= print

solve :: C.ByteString -> Int -> Int
solve k d = lo'!0 .+. hi'!0 .+. (-1) where
  rt r v = U.concat [U.drop (0 .-. r) v, U.take (0 .-. r) v]
  lo = U.cons 1 $ U.replicate (d-1) 0 :: U.Vector Int
  hi = U.replicate d 0 :: U.Vector Int
  (lo', hi') = C.foldl' dp (lo, hi) k
  dp (lo, hi) c = (lo', hi') where
    r = digitToInt c
    lo' = rt r lo
    hi' = V.foldl1' (U.zipWith (.+.)) $ V.concat [V.iterateN 10 (rt 1) hi, V.iterateN r (rt 1) lo]
  x .-. y = (x-y) `mod` d

(.+.) :: Int -> Int -> Int
x .+. y = (x+y) `mod` p where p = 10^9+7 :: Int
infixl 6 .+.
