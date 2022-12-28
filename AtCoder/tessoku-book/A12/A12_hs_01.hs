-- https://atcoder.jp/contests/tessoku-book/submissions/35757216
import Data.ByteString.Char8 as BS ( getLine, readInt, words )
import Data.Maybe ( fromJust )
import qualified Data.Vector.Unboxed as UV

main :: IO ()
main = do
  [n, k] <- fmap (fst . fromJust . BS.readInt) . BS.words <$> BS.getLine :: IO [Int]
  as <- fmap (fst . fromJust . BS.readInt) . BS.words <$> BS.getLine
  let as1 = UV.fromList as
  print $ bsearch 1 1000000000 (check k as1)

check :: Int -> UV.Vector Int -> Int -> Bool
check k as t = k <= UV.foldl (\acc x -> acc + t `div` x) 0 as

bsearch :: Int -> Int -> (Int -> Bool) -> Int
bsearch left right cond = r1 left right where
  r1 left right
    | left >= right = left
    | cond mid = r1 left mid
    | otherwise = r1 (mid + 1) right
   where mid = (left + right) `div` 2
