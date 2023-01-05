-- https://atcoder.jp/contests/tessoku-book/submissions/35452798
import qualified Data.ByteString.Char8 as BS
import Data.Char ( isSpace )
import Data.List ( unfoldr )
import Data.Array ( elems, accumArray )

main :: IO ()
main = do
  [n] <- bsGetLnInts
  as <- bsGetLnInts
  let ans = tba40 n as
  print ans

bsGetLnInts :: IO [Int]
bsGetLnInts = unfoldr (BS.readInt . BS.dropWhile isSpace) <$> BS.getLine

tba40 :: Int -> [Int] -> Int
tba40 n as = sum [div (c * pred c * (c-2)) 6 | c <- elems cnts, c > 2]
  where cnts = accumArray (+) 0 (1,100) [(a,1) | a <- as]
