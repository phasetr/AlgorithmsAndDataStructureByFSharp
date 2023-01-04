-- https://atcoder.jp/contests/tessoku-book/submissions/35448829
import Control.Monad ( replicateM )
import qualified Data.ByteString.Char8 as BS
import Data.Char ( isSpace )
import Data.List ( unfoldr )
import Data.Array ( elems, accumArray )

main :: IO ()
main = do
  [d,n] <- bsGetLnInts
  lrhs <- replicateM n bsGetLnInts
  let ans = tba38 d n lrhs
  print ans

bsGetLnInts :: IO [Int]
bsGetLnInts = unfoldr (BS.readInt . BS.dropWhile isSpace) <$> BS.getLine

tba38 :: Int -> Int -> [[Int]] -> Int
tba38 d n lrhs = sum $ elems $ accumArray min 24 (1,d) [(i,h) | (l:r:h:_) <- lrhs, i <- [l..r]]
