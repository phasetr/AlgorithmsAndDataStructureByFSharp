-- https://atcoder.jp/contests/dp/submissions/21183790
import qualified Data.ByteString.Char8 as C
import Data.List
import qualified Data.Vector.Unboxed as U
import Data.Vector.Unboxed ((!))

main :: IO ()
main = get >>= \(n:k:_) -> getv (n^2) >>= print . solve n k where
  get = unfoldr (C.readInt . C.dropWhile (<'+')) <$> C.getLine
  getv t = U.unfoldrN t (C.readInt . C.dropWhile (<'+')) <$> C.getContents

solve :: Integral t => Int -> t -> U.Vector Int -> Int
solve n k = sm . flip pwr k where
  dot = (sm .) . U.zipWith (○)
  x ○ y = (x*y) `mod` p
  sm = U.foldl1' (((`mod` p) .) . (+))
  p = 10^9+7 :: Int

  pwr a k
    | k==1      = a
    | odd k     = a ⊗ pwr a (k-1)
    | otherwise = let b = pwr a (k `div` 2) in b ⊗ b
  a ⊗ b = U.generate (n^2) (\k -> let (i,j)=k `quotRem` n in dot (row a i) (row b' j))
    where b' = trn b
  row a i = U.unsafeSlice (i*n) n a
  trn a = U.generate (n^2) (\i -> let (q,r)=i `quotRem` n in a!(r*n+q))
