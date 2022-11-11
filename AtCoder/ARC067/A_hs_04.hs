-- https://atcoder.jp/contests/abc052/submissions/3337674
import Data.List ( group, sort, unfoldr )

f :: Int -> [Int]
f n = unfoldr g n where
  g 1 = Nothing
  g k = let (_, r:_) = break ((== 0) . (k `mod`)) [2 .. n] in Just (r, k `div` r)

main :: IO ()
main = do
  n <- readLn :: IO Int
  let as = concatMap f [1 .. n]
  let bs = fmap ((+ 1) . length) . group $ sort as
  let ans = foldr (\x a -> (x * a) `mod` p) 1 bs
  print ans
  where p = 10^9 + 7
