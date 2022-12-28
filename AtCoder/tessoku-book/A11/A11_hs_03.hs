-- https://atcoder.jp/contests/tessoku-book/submissions/35223784
import qualified Data.ByteString.Char8 as BS
import Data.Char ( isSpace )
import Data.Functor ( (<&>) )
import Data.List ( unfoldr )
import qualified Data.IntMap as IM

tba11 :: Int -> Int -> [Int] -> Int
tba11 n x as = IM.fromAscList (zip as [1..]) IM.! x
-- 内部的に二分探索

main :: IO ()
main = do
  [n,x] <- bsGetLnInts
  as <- bsGetLnInts
  let ans = tba11 n x as
  print ans

bsGetLnInts :: IO [Int]
bsGetLnInts = BS.getLine <&> unfoldr (BS.readInt . BS.dropWhile isSpace)
