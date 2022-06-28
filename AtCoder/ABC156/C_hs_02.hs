-- https://atcoder.jp/contests/abc156/submissions/24556339
import Data.Char ( isSpace )
import Data.List ( foldl', sort, unfoldr )
import Data.Maybe ( fromJust )
import qualified Data.ByteString.Char8 as BS

fatigue :: [Int] -> Int -> Int
fatigue xs place = foldl' (+) 0 [(x - place) ^ 2 | x <- xs]

solve :: [Int] -> Int
solve xs = minimum $ [fatigue xs p | p <- [minX..maxX]] where
  xs' = sort xs
  minX = head xs'
  maxX = last xs'

main :: IO ()
main = do
  n <- fst . fromJust . BS.readInt <$> BS.getLine
  xs <- unfoldr (BS.readInt . BS.dropWhile isSpace) <$> BS.getLine
  print $ solve xs
