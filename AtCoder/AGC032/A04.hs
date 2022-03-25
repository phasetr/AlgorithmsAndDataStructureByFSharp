{-
https://atcoder.jp/contests/agc032/submissions/4678951
-}
import Data.List (unfoldr)

main :: IO ()
main = do
  n <- read <$> getLine
  bs <- map read . words <$> getLine
  let
    bis = zip bs [1 ..]
    bs' = reverse . unfoldr next $ bis
  if length bs' < n then print (-1) else mapM_ print bs'

next :: [(Int, Int)] -> Maybe (Int, [(Int, Int)])
next = (uncurry . flip $ fmap . flip (,)) . foldr step (Nothing, [])
  where
    step (bi, i) (Nothing, xs) | bi == i = (Just bi, map (fmap pred) xs)
    step bi (t, xs) = (t, bi : xs)
