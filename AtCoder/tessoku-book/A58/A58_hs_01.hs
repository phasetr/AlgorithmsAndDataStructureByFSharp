-- https://atcoder.jp/contests/tessoku-book/submissions/35639704
import Control.Monad ( replicateM_ )
import qualified Data.ByteString.Char8 as BS
import Data.Char ( isSpace )
import Data.List ( unfoldr )

import qualified Data.Vector.Unboxed.Mutable as MUV
import Data.Bits ( Bits(testBit, shiftR) )

main = do
  [n,q] <- bsGetLnInts
  let d = length $ takeWhile (0 <) $ iterate (flip shiftR 1) (pred n)
  v <- MUV.replicate (2 ^ succ d - 1) 0
  replicateM_ q $ do
    qi <- bsGetLnInts
    case qi of
      (1:p:x:_) -> case1 d v (pred p) x
      (2:l:r:_) -> case2 d v (pred l) (pred r) >>= print
      _err -> error "not come here"

bsGetLnInts :: IO [Int]
bsGetLnInts = unfoldr (BS.readInt . BS.dropWhile isSpace) <$> BS.getLine

bits d x = map (testBit x) [d-1,d-2..0]

case1 d v p x = loop (bits d p) 0 where
  loop [] i = MUV.write v i x
  loop (b:bs) i = do
    loop bs (i + i + if b then 2 else 1)
    a <- MUV.read v (i + i + 1)
    b <- MUV.read v (i + i + 2)
    MUV.write v i (max a b)

case2 d v l r = loop 0 (2^d) 0 where
  loop a b i
    | l <= a && b <= r = MUV.read v i
    | b <= l || r <= a = return minBound
    | otherwise =
      do
        let m = div (a + b) 2
        a <- loop a m (i + i + 1)
        b <- loop m b (i + i + 2)
        return $ max a b
