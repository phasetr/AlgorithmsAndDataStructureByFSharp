-- https://atcoder.jp/contests/abc107/submissions/3081328
import qualified Data.ByteString.Char8 as B
import Data.Char ( isSpace )
import Data.List ( unfoldr )

main :: IO ()
main = do
  [_, k] <- readInts
  xs <- readInts
  print $ solve k xs

readInts :: IO [Int]
readInts = unfoldr (B.readInt . B.dropWhile isSpace) <$> B.getLine

solve :: Int -> [Int] -> Int
solve k xs = minimum $ zipWith cost (drop (k-1) xs) xs

cost :: Int -> Int -> Int
cost x y
  | x <= 0    = -y
  | y >= 0    = x
  | x + y < 0 = 2 * x - y
  | otherwise = x - 2 * y
