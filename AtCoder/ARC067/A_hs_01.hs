-- https://atcoder.jp/contests/abc052/submissions/16231922
import qualified Data.IntMap as IM
main :: IO ()
main = print . solve =<< readLn

solve :: Integral a => IM.Key -> a
solve n = IM.foldr (\i s -> (i+1) * s `mod` (10^9+7)) 1 $ foldr f IM.empty [2..n] where
  f :: Num a => IM.Key -> IM.IntMap a -> IM.IntMap a
  f k m = foldr (\i -> IM.insertWith (+) i 1) m $ g 2 k
  g :: Integral t => t -> t -> [t]
  g i k
    | k == 1 = []
    | r == 0 = i : g i q
    | i*i>k = [k]
    | otherwise = g (i+1) k
    where (q,r) = divMod k i
