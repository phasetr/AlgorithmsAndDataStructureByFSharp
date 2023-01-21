-- https://atcoder.jp/contests/tessoku-book/submissions/35217926
import Data.Maybe ( fromJust )
import qualified Data.ByteString.Char8 as BS

readInt = fst . fromJust . BS.readInt
readIntList = map readInt . BS.words
getInt = readInt <$> BS.getLine
getIntList = readIntList <$> BS.getLine

main :: IO ()
main = do
  n <- getInt
  as <- flip zip [1..] <$> getIntList
  let ans = tail . map fst $ scanl proc (0, []) as
  putStrLn . unwords $ map show ans

proc :: (Ord a1, Num b, Num a2) => (a2, [(a1, b)]) -> (a1, b) -> (b, [(a1, b)])
proc (_, []) (a, d) = (-1, [(a, d)])
proc (_, (xa, da) : xs) (a, d)
  | xa > a = (da, (a, d) : (xa, da) : xs)
  | otherwise = proc (0, xs) (a, d)
