-- https://atcoder.jp/contests/abc075/submissions/1687806
import qualified Data.IntMap as IM
import qualified Data.Vector as V
main :: IO ()
main = do
  [n,m] <- map read . words <$> getLine
  print . solve n m . map (map read.words) . lines =<< getContents
solve :: (Num a, Foldable t) => Int -> p -> t [Int] -> a
solve n m abs = fst (f g(-1)0 IM.empty)-1 where
  g = V.accum (flip(:)) (V.replicate n []) $ concatMap ((\[a,b] -> [(a,b),(b,a)]) . map pred) abs
f :: (Foldable t, Num a) => V.Vector (t Int) -> Int -> IM.Key -> IM.IntMap Int -> (a, IM.IntMap Int)
f g s t v = (c+if p==w IM.! t then 1 else 0,w) where
  p = IM.size v
  (c,w) = foldr h (0,IM.insert t p v) $ g V.! t
  h i a@(c,v)
    | i==s = a
    | IM.member i v = (c,IM.adjust(min(v IM.! i))t v)
    | otherwise = let (d,w) = f g t i v in (c+d,IM.adjust(min(w IM.! i))t w)
