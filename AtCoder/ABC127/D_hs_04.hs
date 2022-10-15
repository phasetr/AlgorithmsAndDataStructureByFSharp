-- https://atcoder.jp/contests/abc127/submissions/5620277
--editorial
import qualified Data.ByteString.Char8 as C
import Data.List ( sort, sortOn, unfoldr )
import Control.Monad ( replicateM )
import Data.Ord ( Down(Down) )

r' :: IO [Int]
r'  = unfoldr (C.readInt . C.dropWhile (==' ')) <$> C.getLine

rp :: IO (Int,Int)
rp  = toTup . unfoldr (C.readInt . C.dropWhile (==' ')) <$> C.getLine

toTup :: [b] -> (b, b)
toTup [a,b] = (a,b)
toTup _ = error "not come here"

main :: IO ()
main = do
  [n,m] <- r'
  as <- sort <$> r'
  bcs <- sortOn (Down . snd) <$> replicateM m rp
  let bcsx = concatMap (uncurry replicate) bcs ++ repeat 0
  print $ sum (zipWith max bcsx as)
