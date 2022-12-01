-- https://atcoder.jp/contests/abc102/submissions/2777734
import Data.List ( sort, unfoldr )
import qualified Data.ByteString.Char8 as B

main :: IO ()
main = do
  n <- readLn
  as <- sort . zipWith (flip (-)) [1..] . unfoldr (B.readInt . B.dropWhile(==' ')) <$> B.getLine
  let m = as !! (n `div` 2)
  print $ sum $ map (\a->abs $ a-m) as
