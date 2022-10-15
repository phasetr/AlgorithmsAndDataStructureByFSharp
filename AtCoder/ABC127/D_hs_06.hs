-- https://atcoder.jp/contests/abc127/submissions/8755649
import qualified Data.ByteString.Char8 as BC
import Data.Maybe ( fromJust )
import Data.List ( sort, sortOn )
import Data.Ord ( Down(Down) )

readIntsLine :: IO [Int]
readIntsLine = map (fst . fromJust . BC.readInt) . BC.words <$> BC.getLine

readIntsLines :: IO [[Int]]
readIntsLines = map (map (fst . fromJust . BC.readInt) . BC.words) . BC.lines <$> BC.getContents

solve :: [Int] -> [(Int, Int)] -> [Int]
solve as [] = as
solve [] _ = []
solve (a:as) (bc:bcs) = res : solve as (nextbc ++ bcs)
  where (res, nextbc) = proc a bc

proc :: Int -> (Int, Int) -> (Int, [(Int, Int)])
proc a (b, c)
  | a >= c = (a, [(b, c)])
  | b == 1 = (c, [])
  | otherwise = (c, [(b - 1, c)])

main :: IO ()
main = do
  getLine
  as <- sort <$> readIntsLine
  bcs <- sortOn (Down . snd) . map (\[a,b] -> (a,b)) <$> readIntsLines
  print . sum $ solve as bcs
