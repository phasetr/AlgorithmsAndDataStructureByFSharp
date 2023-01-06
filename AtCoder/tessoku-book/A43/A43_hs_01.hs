-- https://atcoder.jp/contests/tessoku-book/submissions/35455731
import Control.Monad ( replicateM )
import qualified Data.ByteString.Char8 as BS
import Data.Char ( isSpace )
import Data.List ( unfoldr )

main :: IO ()
main = do
  [n,l] <- bsGetLnInts
  abs <- replicateM n $ do
    li <- BS.getLine
    let Just (a,li1) = BS.readInt li
    let t = BS.index li1 1
    return (a,t)
  let ans = tba43 n l abs
  print ans

bsGetLnInts :: IO [Int]
bsGetLnInts = unfoldr (BS.readInt . BS.dropWhile isSpace) <$> BS.getLine

tba43 :: Int -> Int -> [(Int,Char)] -> Int
tba43 n l abs = maximum $ map f abs where
  f (a, 'E') = l - a
  f (a, _) = a
