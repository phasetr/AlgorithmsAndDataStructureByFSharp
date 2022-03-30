-- https://atcoder.jp/contests/agc002/submissions/827704
import qualified Data.Vector.Unboxed as V
import qualified Data.Vector.Unboxed.Mutable as MV
import qualified Data.ByteString.Char8 as BS
import Data.Maybe (fromJust)

main :: IO ()
main = do
  [n, m] <- map read . words <$> getLine
  q <- V.replicateM m $ do
    [x, y] <- map (fst . fromJust . BS.readInt) . BS.words <$> BS.getLine
    return (x-1, y-1)
  let
    ans = V.create $ do
      vn <- MV.replicate n (1 :: Int)
      vb <- MV.replicate n False
      MV.write vb 0 True
      V.forM_ q $ \(x, y) -> do
        red <- MV.read vb x
        MV.modify vn (+1) y
        MV.modify vb (red ||) y
        MV.modify vn (subtract 1) x
        l <- MV.read vn x
        MV.modify vb (\b -> (l /= 0) && b) x
      return vb
  print $ V.length $ V.filter id ans

