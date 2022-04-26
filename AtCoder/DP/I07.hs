-- https://atcoder.jp/contests/dp/submissions/4057744
import qualified Data.Vector.Unboxed as UV

main :: IO ()
main = do
  n <- readLn
  ps <- UV.fromListN n . map read . words <$> getLine :: IO (UV.Vector Double)
  print $ f n ps

f :: Int -> UV.Vector Double -> Double
f n = UV.sum . UV.take (n`div`2+1) . UV.foldl' proc (UV.cons 1 $ UV.replicate n 0) where
  proc v0 p = UV.cons (UV.head v0 * p) $ UV.map (\j->(v0 UV.! (j-1))*(1-p) + (v0 UV.! j)*p) $ UV.enumFromTo 1 n
