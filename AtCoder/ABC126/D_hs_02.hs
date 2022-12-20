-- https://atcoder.jp/contests/abc126/submissions/31097036
import Control.Monad ( replicateM )
import qualified Data.ByteString.Char8 as BS
import Data.Char ( isSpace )
import Data.Functor ( (<&>) )
import Data.List ( unfoldr )
import Data.Array ( elems, array, (!), accumArray )

main :: IO ()
main = do
  [n] <- readLn
  uvws <- replicateM (n-1) (BS.getLine <&> unfoldr (BS.readInt . BS.dropWhile isSpace))
  let ans = abc126d n uvws
  mapM_ print ans

abc126d :: Int -> [[Int]] -> [Int]
abc126d n uvws = elems c where
  g = accumArray (flip (:)) [] (1,n) [p | (u:v:w:_) <- uvws, p <- [(u,(v,w)),(v,(u,w))]]
  c = array (1,n) $ recur 0 1 0 []
  recur p i bw rest = (i,bw) : foldr ($) rest [recur i c (bwf w bw) | (c,w) <- g ! i, c /= p]
  bwf w bw | odd w = 1 - bw | otherwise = bw
