-- https://atcoder.jp/contests/abc141/submissions/7529116
-- https://github.com/minoki/my-atcoder-solutions
import Data.Char (isSpace)
import Data.Int (Int64)
import Data.List (unfoldr)
import qualified Data.ByteString.Char8 as BS
import qualified Data.IntMap.Strict as IntMap
import Data.Monoid ( Sum(Sum, getSum) )

discount :: Int -> IntMap.IntMap Int -> IntMap.IntMap Int
discount 0 p = p
discount m p =
  case IntMap.maxViewWithKey p of
    Nothing -> p
    Just ((k, l), p')
      | m < l -> IntMap.insertWith (+) (k `quot` 2) m $ IntMap.insert k (l - m) p'
      | otherwise -> discount (m - l) $ IntMap.insertWith (+) (k `quot` 2) l p'

main :: IO ()
main = do
  [n,m] <- unfoldr (BS.readInt . BS.dropWhile isSpace) <$> BS.getLine
  p <- IntMap.fromListWith (+) . map (\x -> (x,1)) . unfoldr (BS.readInt . BS.dropWhile isSpace) <$> BS.getLine
  let result :: Int64
      result = getSum $ IntMap.foldMapWithKey (\k l -> Sum $! fromIntegral k * fromIntegral l) $ discount m p
  print result
