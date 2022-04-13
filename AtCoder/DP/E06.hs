-- https://atcoder.jp/contests/dp/submissions/4015749
import Data.List ( unfoldr )
import qualified Data.ByteString.Char8 as B
import qualified Data.Vector.Unboxed as UV

main :: IO ()
main = do
  [n,w] <- map read . words <$> getLine
  wvs <- UV.replicateM n $ (\[a,b] -> (a,b))
         . unfoldr (B.readInt . B.dropWhile (<'!')) <$> B.getLine
  print $ solve w wvs

solve :: Int -> UV.Vector (Int,Int) -> Int
solve w wvs = UV.length $ UV.takeWhile (<=w)
  $ UV.foldl' p (UV.replicate 100000 inf) wvs
  where
    inf = maxBound `div` 2
    p v0 (wi,vi) = UV.generate 100000 m where
      m j | j < vi    = min (v0 UV.! j) wi
          | otherwise = min (v0 UV.! j) (wi + v0 UV.! (j-vi))
