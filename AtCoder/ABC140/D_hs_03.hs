-- https://atcoder.jp/contests/abc140/submissions/7398221
-- https://github.com/minoki/my-atcoder-solutions
import Data.Char (isSpace)
import Data.List (unfoldr)
import qualified Data.Vector.Unboxed as U
import qualified Data.ByteString.Char8 as BS

main :: IO ()
main = do
  [n,k] <- unfoldr (BS.readInt . BS.dropWhile isSpace) <$> BS.getLine
  s <- BS.getLine
  let xs = U.generate (BS.length s) (BS.index s)
  let m = U.length $ U.filter id $ U.zipWith (==) xs (U.tail xs)
  print $ min (m + 2 * k) (n - 1)
