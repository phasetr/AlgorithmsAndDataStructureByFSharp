-- https://atcoder.jp/contests/abc070/submissions/1512590
import Data.Maybe ( fromJust )
import qualified Data.ByteString.Char8 as B
import qualified Data.Vector as V
import qualified Data.IntMap as IM
main :: IO ()
main = B.getContents
  >>= mapM_ (mapM_ print . solve) . analyze . map (map (fst . fromJust . B.readInt) . B.words) . B.lines
analyze :: [[Int]] -> [(Int, [[Int]], Int, Int, [[Int]])]
analyze ([n]:cs) = (n,abcs,q,k,xys) : analyze rs where
  (abcs,[q,k]:qs) = splitAt (n-1) cs
  (xys,rs) = splitAt q qs
analyze [] = []
solve :: Foldable t => (Int, t [Int], c, Int, [[IM.Key]]) -> [Int]
solve (n,abcs,q,k,xys) = map (\[x,y] -> d IM.! x + d IM.! y) xys where
  g = V.accum (flip(:)) (V.replicate (n+1) [] ) $ concatMap (\[a,b,c] -> [(a,(b,c)),(b,(a,c))]) abcs
  d = f IM.empty k (-1)0
  f m t s c = foldr (\(i,d) m -> if i==s then m else f m i t (c+d)) (IM.insert t c m) $ g V.! t
