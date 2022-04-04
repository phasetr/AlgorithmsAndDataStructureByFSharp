-- https://atcoder.jp/contests/abc061/submissions/10765495
import Control.Monad (replicateM)
import Data.List (sort)
import qualified Data.ByteString.Char8 as BS
main :: IO ()
main = do
  [n,k] <- map read . words <$> getLine
  ab <- replicateM n (map (read . BS.unpack) . BS.words
                      <$> BS.getLine)
  print(f (sort ab) k)
    where
      f ([a,b]:ab) k = if b<k then f ab (k-b) else a
      f _ _ = undefined
