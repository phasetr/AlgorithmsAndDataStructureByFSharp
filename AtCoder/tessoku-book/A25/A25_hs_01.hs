-- https://atcoder.jp/contests/tessoku-book/submissions/35367647
import Control.Monad ( replicateM )
import Data.List ()

tba25 :: Int -> Int -> [String] -> Int
tba25 h w css = last final where
  initial = 1 : replicate (pred w) 0
  final = foldl step initial css
  step xs cs = tail xs1
    where xs1 = 0 : zipWith3 f cs xs xs1
  f '#' _ _ = 0
  f _ a b = a + b

main :: IO ()
main = do
  [h,w] <- getLnInts
  css <- replicateM h getLine
  let ans = tba25 h w css
  print ans

getLnInts :: IO [Int]
getLnInts = map read . words <$> getLine
