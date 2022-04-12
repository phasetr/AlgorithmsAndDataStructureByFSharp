-- https://atcoder.jp/contests/dp/submissions/4015221
import Control.Monad ( replicateM )
import Data.List ( foldl', unfoldr )
import qualified Data.ByteString.Char8 as B
import qualified Data.Vector.Unboxed as UV

r2 :: [b] -> (b, b)
r2 [a,b] = (a,b)
r2 _ = undefined

main :: IO ()
main = do
  [n,w] <- map read . words <$> getLine
  wvs <- replicateM n
    $ (\[a,b] -> (a,b))
    . unfoldr (B.readInt . B.dropWhile (<'!')) <$> B.getLine
  print $ f n w wvs

f :: (UV.Unbox c, Foldable t, Ord c, Num c) => p -> Int -> t (Int, c) -> c
f n w = (UV.! w).foldl' p (UV.replicate (w+1) 0) where
  p v0 (wi,vi) = UV.zipWith max v0 (UV.replicate wi 0 UV.++ UV.map (+vi) v0)
