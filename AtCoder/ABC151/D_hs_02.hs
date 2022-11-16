-- https://atcoder.jp/contests/abc151/submissions/12201027
import Control.Monad ( replicateM )
import qualified Data.Map as M

main :: IO ()
main = do
  [h, w] <- map read . words <$> getLine
  maze <- toMap h w <$> replicateM h getLine
  print $ maximum [pathLength maze i j| i <- [1..h], j <- [1..w]]

toMap :: (Ord a, Ord t, Num a, Num t, Enum a, Enum t) => a -> t -> [[Char]] -> M.Map (a, t) Char
toMap h w xss = toMap' h w 1 1 xss where
  toMap' h w _ _ [] = M.fromList [((i,j),'#')|i<-[0..h+1],j<-[0..w+1],i==0||i==h+1||j==0||j==w+1]
  toMap' h w i j ([]:xss) = toMap' h w (i+1) 1 xss
  toMap' h w i j ((x:xs):xss) = M.insert (i,j) x (toMap' h w i (j+1) (xs:xss))

pathLength :: (Ord a, Ord b, Num a, Num b, Num t) => M.Map (a, b) Char -> a -> b -> t
pathLength maze i j = bfs 0 [((i,j), 0)] maze where
  bfs l [] maze = l
  bfs l (((i,j),d) : q) maze
    | maze M.! (i,j) == '#' = bfs l q maze
    | otherwise = bfs d (q ++ r) $ M.insert (i,j) '#' maze
    where r = [((x,y),d+1)|(x,y)<-[(i-1,j),(i+1,j),(i,j-1),(i,j+1)], maze M.! (x,y) == '.']

test :: IO ()
test = do
  let (h,w,xss) = (3,5,["...#.",".#.#.",".#..."])
  print $ toMap h w xss
