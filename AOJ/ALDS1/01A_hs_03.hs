-- http://judge.u-aizu.ac.jp/onlinejudge/description.jsp?id=ALDS1_1_A&lang=ja
-- http://judge.u-aizu.ac.jp/onlinejudge/review.jsp?rid=3707884#1
insertList :: (Ord a) => [a] -> a -> [a]
insertList [] a = [a]
insertList xxs@(x:xs) a
  | a < x = a : xxs
  | otherwise = x : insertList xs a

solve :: [Int] -> [[Int]]
solve xs = tail $ zipWith (++) (scanl insertList [] xs) (scanr (:) [] xs)

main :: IO ()
main =
  getLine >> getLine >>=
  putStr . unlines . map (unwords . map show) . solve
  . map (read :: String -> Int) . words

test :: IO ()
test = do
  print $ solve [5,2,4,6,1,3] == [[5,2,4,6,1,3],[2,5,4,6,1,3],[2,4,5,6,1,3],[2,4,5,6,1,3],[1,2,4,5,6,3],[1,2,3,4,5,6]]
  print $ solve [1,2,3] == [[1,2,3],[1,2,3],[1,2,3]]
