-- https://atcoder.jp/contests/dp/submissions/21122647
import Control.Monad ( forM_ )
import Control.Monad.ST ( runST )
import Data.Bits ( Bits((.&.)) )
import qualified Data.ByteString.Char8 as C
import Data.List ( unfoldr )
import qualified Data.Vector.Unboxed.Mutable as UM

main :: IO ()
main = solve <$> readLn <*> get <*> get >>= print where
  get = unfoldr (C.readInt . C.dropWhile (<'+')) <$> C.getLine

solve :: (Num a, UM.Unbox a, Ord a) => Int -> [Int] -> [a] -> a
solve n hs as = runST $ do
  bt <- UM.replicate (n+1) 0
  let
    dn s i
      | i>0       = UM.unsafeRead bt i >>= flip dn (i .&. (i-1)) . max s
      | otherwise = return s
    up i x
      | i<=n      = UM.unsafeModify bt (max x) i >> up (i + i .&. (-i)) x
      | otherwise = return ()
  forM_ (zip hs as) $ \(h,a) -> dn 0 h >>= up h . (a+)
  dn 0 n
