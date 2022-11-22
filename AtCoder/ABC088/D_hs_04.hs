-- https://atcoder.jp/contests/abc088/submissions/4435091
import Control.Monad ( replicateM )
import Data.Map (Map)
import qualified Data.Map as M
import Data.Sequence (Seq,ViewR(..),(<|))
import qualified Data.Sequence as Sq

main = do
  [h,w] <- map read.words <$> getLine
  s <- replicateM h getLine
  print $ solve h w (generateMap s)

solve height width map
  | shortest == -1 = -1
  | otherwise = M.size (M.filter (/='#') map) - shortest
  where
    shortest = go map $ Sq.singleton ((1,1),1)
    go map q = inner map $ Sq.viewr q
    inner map (q:>(p@(x,y),l))
      | x == width && y == height = l
      | map!?p == Just '.' = go (M.insert p '%' map) ((e,l+1)<|(w,l+1)<|(n,l+1)<|(s,l+1)<|q)
      | otherwise = go map q
      where [e,w,n,s] = [(x+dx,y+dy) | (dx,dy) <- [(1,0),(-1,0),(0,1),(0,-1)]]
    inner map EmptyR = -1

generateMap = go 1 1 where
  go _ _ [] = M.empty
  go x y ([]:sss) = go 1 (y+1) sss
  go x y ((s:ss):sss) = M.insert (x,y) s $ go (x+1) y (ss:sss)

(!?) :: Ord k => Map k a -> k -> Maybe a
map !? k = M.lookup k map
