-- https://atcoder.jp/contests/tessoku-book/submissions/35448711
import qualified Data.ByteString.Char8 as BS
import Data.Char ( isSpace )
import Data.List ( unfoldr )

main :: IO ()
main = do
  [n,m,b] <- bsGetLnInts
  as <- bsGetLnInts
  cs <- bsGetLnInts
  let ans = tba37 n m b as cs
  print ans

bsGetLnInts :: IO [Int]
bsGetLnInts = unfoldr (BS.readInt . BS.dropWhile isSpace) <$> BS.getLine

tba37 :: Int -> Int -> Int -> [Int] -> [Int] -> Int
tba37 n m b as cs = m * (sum as + n * b) + n * sum cs
