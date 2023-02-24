-- https://atcoder.jp/contests/tessoku-book/submissions/35581035
import qualified Data.ByteString.Char8 as BS
import Data.Char ( isSpace )
import Data.Functor ( (<&>) )
import Data.List ( unfoldr )

main :: IO ()
main = do
  [n,x] <- bsGetLnInts
  a <- BS.getLine
  let ans = tbb52 n x a
  BS.putStrLn ans

bsGetLnInts :: IO [Int]
bsGetLnInts = BS.getLine <&> unfoldr (BS.readInt . BS.dropWhile isSpace)

tbb52 :: Int -> Int -> BS.ByteString -> BS.ByteString
tbb52 n x a = BS.concat [BS.take lb a, BS.replicate (ub-lb) '@', BS.drop ub a] where
  lb = last $ takeWhile (('#' /=) . BS.index a) [x-1,x-2..0]
  ub = succ $ last $ takeWhile (('#' /=) . BS.index a) [x-1..pred n]
