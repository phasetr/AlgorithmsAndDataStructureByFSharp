-- https://atcoder.jp/contests/tessoku-book/submissions/35596241
import Control.Monad ( replicateM )
import qualified Data.ByteString.Char8 as BS
import Data.Char ( isSpace )
import Data.Functor ( (<&>) )
import Data.List ( unfoldr, mapAccumL )

import qualified Data.IntMap as IM

main :: IO ()
main = do
  [n] <- bsGetLnInts
  as <- replicateM n (bsGetLnInts <&> head)
  let ans = tbb54 n as
  print ans

bsGetLnInts :: IO [Int]
bsGetLnInts = BS.getLine <&> unfoldr (BS.readInt . BS.dropWhile isSpace)

tbb54 :: Int -> [Int] -> Int
tbb54 n as = sum $ snd $ mapAccumL step IM.empty as

step :: Num b => IM.IntMap b -> IM.Key -> (IM.IntMap b, b)
step m a = (IM.insertWith (+) a 1 m, IM.findWithDefault 0 a m)
