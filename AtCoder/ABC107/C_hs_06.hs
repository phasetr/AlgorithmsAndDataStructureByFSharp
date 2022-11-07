-- https://atcoder.jp/contests/abc107/submissions/3148218
import Control.Arrow (second)
import qualified Data.Vector.Unboxed as V
import qualified Data.ByteString.Char8 as B

solve :: Int -> Int -> V.Vector Int -> Int
solve n k xs = (\t -> if null t then 0 else minimum t) $ map (\i -> dist (xs V.! i) (xs V.! (i+k-1))) [0..n-k] where
  dist x y =
    let
      l = max (-x) 0
      r = max y 0
    in
      l + r + min l r

main :: IO ()
main = do
  [n,k] <- map (fst . (\(Just x) -> x) . B.readInt) . B.words <$> B.getLine
  xs <- V.unfoldrN n (fmap (second B.tail) . B.readInt) <$> B.getLine
  print $ solve n k xs
