-- https://atcoder.jp/contests/abc050/submissions/10320543
import Data.Array.Unboxed ( Ix, (!), accumArray, IArray, UArray )
import qualified Data.ByteString.Char8 as C
import Data.List ( unfoldr )

main :: IO ()
main = sol <$> readLn <*> get >>= print

get :: IO [Int]
get = unfoldr (C.readInt . C.dropWhile (==' ')) <$> C.getLine

sol :: Int -> [Int] -> Int
sol n as = if check n ar then pow2 (n `div` 2) else 0
  where ar = accumArray (+) 0 (0,n-1) $ zip as (repeat 1) :: UArray Int Int

check :: (Integral a1, IArray a2 a3, Ix a1, Num a3, Eq a3) => a1 -> a2 a1 a3 -> Bool
check n ar = if odd n
    then ar!0==1 && all ((==2) . (ar!)) [2,4..n-1]
    else all ((==2) . (ar!)) [1,3..n-1]

pow2 :: Integral t => t -> Int
pow2 n
  | n == 0    = 1
  | odd n     = 2*r `mod` p
  | otherwise = r
  where
  q = pow2 (n `div` 2)
  r = q*q `mod` p
  p = 10^9+7 :: Int
