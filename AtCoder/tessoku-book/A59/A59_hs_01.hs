-- https://atcoder.jp/contests/tessoku-book/submissions/35649934
import Control.Monad ( replicateM_ )
import Control.Monad.Primitive ( PrimMonad(PrimState) )
import qualified Data.ByteString.Char8 as BS
import Data.Char ( isSpace )
import Data.List ( unfoldr )

import qualified Data.Vector.Unboxed.Mutable as MUV
import Data.Bits ( Bits(testBit, shiftR) )

main :: IO ()
main = do
  [n,q] <- bsGetLnInts
  let d = length $ takeWhile (0 <) $ iterate (`shiftR` 1) (pred n)
  v <- MUV.replicate (2 ^ succ d - 1) 0
  replicateM_ q $ do
    qi <- bsGetLnInts
    case qi of
      (1:p:x:_) -> case1 d v (pred p) x
      (2:l:r:_) -> case2 d v (pred l) (pred r) >>= print
      _err -> error "not come here"

bsGetLnInts :: IO [Int]
bsGetLnInts = unfoldr (BS.readInt . BS.dropWhile isSpace) <$> BS.getLine

bits :: Bits a => Int -> a -> [Bool]
bits d x = map (testBit x) [d-1,d-2..0]

case1 :: (Bits a1, PrimMonad m, MUV.Unbox a2, Num a2) => Int -> MUV.MVector (PrimState m) a2 -> a1 -> a2 -> m ()
case1 d v p x = loop (bits d p) 0
  where
    loop [] i = MUV.write v i x
    loop (b:bs) i = do
      loop bs (i + i + if b then 2 else 1)
      a <- MUV.read v (i + i + 1)
      b <- MUV.read v (i + i + 2)
      MUV.write v i (a + b)

case2 :: (Integral b, PrimMonad m, MUV.Unbox a, Num a, Integral t) => b -> MUV.MVector (PrimState m) a -> t -> t -> m a
case2 d v l r = loop 0 (2^d) 0 where
  loop a b i
    | l <= a && b <= r = MUV.read v i
    | b <= l || r <= a = return 0
    | otherwise =
      do
        let m = div (a + b) 2
        a <- loop a m (i + i + 1)
        b <- loop m b (i + i + 2)
        return $ a + b
