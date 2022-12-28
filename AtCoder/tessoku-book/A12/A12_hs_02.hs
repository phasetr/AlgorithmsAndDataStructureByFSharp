-- https://atcoder.jp/contests/tessoku-book/submissions/35852961
import qualified Data.ByteString.Char8 as BS
import Data.Char (isSpace)
import qualified Data.Vector.Unboxed as VU

compute :: VU.Vector Int -> Int -> Int
compute as x = VU.sum $ VU.map (\i -> x `div` i) as

search :: Int -> (Int, Int) -> (Int -> Int) -> Int
search x (l, r) f
  | l > r = m + 1
  | x <= f m = search x (l, m - 1) f
  | otherwise = search x (m + 1, r) f
  where m = (l + r) `div` 2

main :: IO ()
main = do
  [n, k] <- map read . words <$> getLine
  as <- VU.unfoldrN n (BS.readInt . BS.dropWhile isSpace) <$> BS.getLine
  print $ search k (1, 10 ^ (9 :: Int)) (compute as)
