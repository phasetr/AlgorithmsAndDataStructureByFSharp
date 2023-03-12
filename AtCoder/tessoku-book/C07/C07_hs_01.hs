-- https://atcoder.jp/contests/tessoku-book/submissions/35953580
import Control.Monad ( replicateM_ )
import qualified Data.ByteString.Char8 as BS
import Data.Char ( isSpace )
import Data.List ( sort, unfoldr )

import qualified Data.IntMap as IM
import Data.Maybe ( fromJust )

main :: IO ()
main = do
  [n] <- bsGetLnInts
  cs <- bsGetLnInts
  let im = IM.fromAscList $ zip (scanl (+) 0 $ sort cs) [0..]
  [q] <- bsGetLnInts
  replicateM_ q $ do
    [x] <- bsGetLnInts
    print $ snd $ fromJust $ IM.lookupLE x im

bsGetLnInts :: IO [Int]
bsGetLnInts = BS.getLine >>= return . unfoldr (BS.readInt . BS.dropWhile isSpace)
