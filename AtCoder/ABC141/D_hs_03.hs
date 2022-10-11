-- https://atcoder.jp/contests/abc141/submissions/18672399
import qualified Data.Set as S

main = do
  [n, m] <- map read . words <$> getLine
  as <- map read . words <$> getLine
  print $ solve m as

solve :: Int -> [Int] -> Int
solve ticket amounts = S.foldr (\(a, _) s -> s + a) 0 $ discount ticket $ S.fromList $ zip amounts [0..]

discount :: Int -> S.Set (Int, Int) -> S.Set (Int, Int)
discount 0 s = s
discount t s = discount (t - 1) newS where
  m = S.findMax s
  new = (fst m `div` 2, snd m)
  newS = S.insert new $ S.deleteMax s
