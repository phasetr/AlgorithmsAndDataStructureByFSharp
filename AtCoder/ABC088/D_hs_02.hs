-- https://atcoder.jp/contests/abc088/submissions/12257710
{-# LANGUAGE TupleSections #-}
import Control.Monad ( replicateM )
import qualified Data.Map as M
import GHC.LanguageExtensions (Extension(TupleSections))
main :: IO ()
main = do
  [h, w] <- map read . words <$> getLine
  (gridMap, whites) <- toMap h w <$> replicateM h getLine
  let l = bfs h w gridMap [((1, 1), 1)]
  print $ if l == -1 then -1 else whites - l

bfs _ _ _ [] = -1
bfs h w g (((i,j),l):q)
  | (i, j) == (h, w) = l
  | g M.! (i,j) == '#' = bfs h w g q
  | otherwise = bfs h w (M.insert (i, j) '#' g) (q ++ neighbors)
  where neighbors = map (, l+1) [(i-1, j), (i+1, j), (i, j-1), (i, j+1)]

toMap h w xss = toMap' h w 1 1 xss where
  toMap' h w _ _ [] = (M.fromList [((i,j),'#')|i<-[0..h+1],j<-[0..w+1],i==0||i==h+1||j==0||j==w+1], 0)
  toMap' h w i j ([]:xss) = toMap' h w (i+1) 1 xss
  toMap' h w i j ((x:xs):xss) = (M.insert (i,j) x map', if x == '.' then ws+1 else ws)
    where (map', ws) = toMap' h w i (j+1) (xs:xss)
