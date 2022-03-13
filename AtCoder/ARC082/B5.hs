{-
https://atcoder.jp/contests/abc072/submissions/14135882
-}
import Data.Maybe (fromJust)
import qualified Data.ByteString.Char8 as B

main :: IO ()
main = print . solve 0 1 . tail
  . map (fst . fromJust . B.readInt) . B.words
  =<< B.getContents

solve :: Int -> Int -> [Int] -> Int
solve k i (a1:a2:as) =
  if i==a1 then solve (k+1) (i+2) as
  else solve k (i+1) (a2:as)
solve k i as =
  if null as || i /= head as then k else k+1
