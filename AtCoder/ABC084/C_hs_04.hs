-- https://atcoder.jp/contests/abc084/submissions/16935988
import Data.Char ( isSpace )
import Data.List ( foldl', tails, unfoldr )
import qualified Data.ByteString.Char8 as B
main :: IO ()
main = mapM_ print . solve . map (unfoldr $ B.readInt . B.dropWhile isSpace) . B.lines =<< B.getContents

solve :: [[Int]] -> [Int]
solve = map (foldl' g 0) . tails . map (\[c,s,f]->(c,s,f)) . tail

g :: Integral a => a -> (a, a, a) -> a
g t (c,s,f) = (max t s+f-1) `div` f * f + c
