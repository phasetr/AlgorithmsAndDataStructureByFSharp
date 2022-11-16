-- https://atcoder.jp/contests/abc151/submissions/15865998
import Control.Monad ( replicateM )
import Data.Array.IArray ( Array, (!), (//), array )
import qualified Data.ByteString.Char8 as BS
type Pos = (Int,Int)
main :: IO ()
main = do
  [h,w] <- map read . words <$> getLine :: IO [Int]
  s <- concat <$> replicateM h (map BS.unpack . BS.words <$> BS.getLine)
  let idxs = (,) <$> [0..h-1] <*> [0..w-1]
      arr :: Array Pos Char
      arr = array ((0,0),(h-1,w-1)) (zip idxs (concat s))
      ms = [bfs arr p | p <- idxs,arr ! p == '.']
      next :: Array Pos Char -> Pos ->  [Pos]
      next s (y,x) = [(ny,nx) | (dy,dx) <- zip [1,0,-1,0] [0,1,0,-1],let (ny,nx) = (y+dy,x+dx),0 <= nx,nx < w,0 <= ny,ny < h,s ! (ny,nx) == '.']

      walk ::Array Pos Char -> Int -> [(Pos,Int)] -> [(Pos,Int)]
      walk _ 0 _ = []
      walk s n ((p,d):ps) = zip ne (repeat (d+1)) ++ walk k (n-1+len) ps where
        ne = next s p
        len = length ne
        k = s // zip ne (repeat '#')
      walk _ _ _ = error "not come here"

      bfs :: Array Pos Char -> Pos -> Int
      bfs s start = postProcess queue where
        queue = (start,0) : walk s' 1 queue
        postProcess = maximum . map snd
        s' = s // [(start,'#')]
  print $ maximum ms
