-- https://atcoder.jp/contests/sumitrust2019/submissions/8755584
import qualified Data.ByteString.Char8 as BS
import Data.List ( foldl' )
import Data.Maybe ( fromJust )

main :: IO ()
main = do
  getLine
  ns <- map (fst . fromJust . BS.readInt) . BS.words <$> BS.getLine
  print . solve $ ns

solve :: [Int] -> Int
solve = fst . foldl' step (1,(0, 0, 0)) where
  modulo = 10^9 +7

  step (0, x) _ = (0, x)
  step (n, (a, b, c)) d
    | a == d && a == b && b == c = (3 * n `mod` modulo, (a+1, b, c))
    | a == d && a == b           = (2 * n `mod` modulo, (a+1, b, c))
    | a == d                     = (n,                  (a+1, b, c))
    | b == d && b == c           = (2 * n `mod` modulo, (a, b+1, c))
    | b == d                     = (n,                  (a, b+1, c))
    | c == d                     = (n,                  (a, b, c+1))
    | otherwise                  = (0,                  (0, 0, 0))
