-- https://atcoder.jp/contests/dp/submissions/26871443
import qualified Data.Vector as V
main :: IO ()
main = do
  [n,w] <- map read . words <$> getLine
  wv <- map (map read . words) . lines <$> getContents
  let dp = foldl (\t [wi,vi] ->
                     V.zipWith min t
                     $ V.replicate vi wi V.++ V.map (+ wi) t) (V.replicate (10^5) $ 10^9+1) wv
  print $ solve (\x->dp V.!x > w) [-1, 10^5]

solve :: Integral a => (a -> Bool) -> [a] -> a
solve c t = last $ head $ dropWhile (\[l,u] -> u-l>1)
  $ iterate (\[l,u] -> (\x -> if c x then [l,x] else [x,u]) $ div (l+u) 2) t
