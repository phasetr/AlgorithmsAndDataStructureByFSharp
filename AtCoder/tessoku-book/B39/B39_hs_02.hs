-- https://atcoder.jp/contests/tessoku-book/submissions/35451563
import Control.Monad ( replicateM )
import qualified Data.ByteString.Char8 as BS
import Data.Char ( isSpace )
import Data.Functor ( (<&>) )
import Data.List ( mapAccumL, unfoldr )
import qualified Data.IntMap as IM
import Data.Array ( accumArray, elems )

main :: IO ()
main = do
  [n,d] <- bsGetLnInts
  xys <- replicateM n bsGetLnInts
  let ans = tbb39 n d xys
  print ans

bsGetLnInts :: IO [Int]
bsGetLnInts = BS.getLine <&> unfoldr (BS.readInt . BS.dropWhile isSpace)

tbb39 :: Int -> Int -> [[Int]] -> Int
tbb39 n d xys = sum es where
  ws = accumArray (flip (:)) [] (1,d) [(x,y) | (x:y:_) <- xys]
  (_, es) = mapAccumL step IM.empty $ elems ws

step :: IM.IntMap Int -> [Int] -> (IM.IntMap Int, Int)
step m ys =
  case IM.lookupMax m1 of
    Nothing    -> (m1, 0)
    Just (v,1) -> (IM.delete v m1, v)
    Just (v,k) -> (IM.insert v (pred k) m1, v)
  where m1 = foldl (\m y -> IM.insertWith (+) y 1 m) m ys
