-- https://atcoder.jp/contests/abc061/submissions/12476168
import Control.Monad (forM_)
import Control.Monad.ST (runST)
import qualified Data.ByteString.Char8 as C
import Data.List (unfoldr)
import Data.Maybe (fromJust)
import qualified Data.Vector.Unboxed as U
import qualified Data.Vector.Unboxed.Mutable as UM

main :: IO ()
main = get >>= print . solve

get :: IO [[Int]]
get = fmap (unfoldr (C.readInt . C.dropWhile (==' '))) . C.lines
  <$> C.getContents

solve :: [[Int]] -> Int
solve ([_,k]:ab) =
  fromJust . U.findIndex (k<=) . U.scanl1' (+) $ runST $ do
  v <- UM.replicate (1+10^5 :: Int) (0 :: Int)
  forM_ ab $ \[a,b] -> UM.modify v (+b) a
  U.freeze v
solve _ = undefined
