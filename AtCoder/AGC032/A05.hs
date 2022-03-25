{-
https://atcoder.jp/contests/agc032/submissions/4674715
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

f :: [(Int, Int)] -> (Maybe Int, [(Int, Int)])
f = foldr step (Nothing, [])
  where
    step (bi, i) (Nothing, xs) | bi == i = (Just bi, map (fmap pred) xs)
    step bi (t, xs) = (t, bi : xs)

next :: [(Int, Int)] -> Maybe (Int, [(Int, Int)])
next xs = case f xs of
  (Nothing, _) -> Nothing
  (Just x, xs') -> Just (x, xs')
