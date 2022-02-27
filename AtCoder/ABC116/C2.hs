-- main=interact$show.sum.(zipWith((max 0.).flip(-))=<<(0:)).tail.map read.words
main :: IO()
main = do
  getLine
  hs <- map read . words <$> getLine :: IO [Int]
  print $ solve hs

-- https://atcoder.jp/contests/abc116/submissions/25804826
solve :: (Ord a, Num a) => [a] -> a
solve hs = sum $ zipWith f (0:hs) hs
  where f = (max 0 .) . flip (-)

-- https://atcoder.jp/contests/abc116/submissions/25804698
solve1 :: [Int] -> Int
solve1 = f 0
  where
    f x []    = 0
    f x (h:k) = max(h-x)0 + f h k
