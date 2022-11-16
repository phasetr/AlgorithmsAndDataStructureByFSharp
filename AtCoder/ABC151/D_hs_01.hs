-- https://atcoder.jp/contests/abc151/submissions/19009847
import qualified Data.ByteString.Char8 as B
import qualified Data.Vector as V
import qualified Data.Set as S
main :: IO ()
main = print . solve =<< (\[h,w] -> (,) (h,w) <$> V.replicateM h B.getLine) . map read . words =<< getLine

solve :: (Ord a, Num a) => ((Int, Int), V.Vector B.ByteString) -> a
solve ((h,w),s) = maximum [f 0 ([(i,j)], S.singleton (i,j)) | i<-[0..h-1], j<-[0..w-1], B.index (s V.! i) j == '.'] where
  f :: Num t => t -> ([(Int, Int)], S.Set (Int, Int)) -> t
  f k (q,m) = if null q then k-1 else f (k+1) (foldr g ([], m) q)

  g :: (Int, Int) -> ([(Int, Int)], S.Set (Int, Int)) -> ([(Int, Int)], S.Set (Int, Int))
  g (x,y) qm =
    foldr (\xy qm@(q,m) -> if S.member xy m then qm else (xy:q, S.insert xy m))
    qm [(i,j) |
        (i,j) <- [(x,y+1), (x+1,y), (x,y-1), (x-1,y)],
        0<=i, i<h, 0<=j, j<w, B.index (s V.!i) j == '.']
