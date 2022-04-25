-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_4_A/review/1568652/hamukichi/Haskell
import qualified Data.Set as S

main :: IO ()
main = do
  getLine
  s <- fmap (S.fromList . map read . words) getLine :: IO (S.Set Int)
  getLine
  t <- fmap (S.fromList . map read . words) getLine
  print $ S.size $ S.intersection s t
