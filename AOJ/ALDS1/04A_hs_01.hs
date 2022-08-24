-- https://onlinejudge.u-aizu.ac.jp/courses/lesson/1/ALDS1/all/ALDS1_4_A
main :: IO ()
main = do
  getLine
  ss <- fmap (map read . words) getLine
  getLine
  ts <- fmap (map read . words) getLine
  print $ solve ss ts
solve :: [Int] -> [Int] -> Int
solve ss = foldl (\acc t -> if t `elem` ss then acc+1 else acc) 0

test :: IO ()
test = do
  print $ solve [1,2,3,4,5] [3,4,1] == 3
  print $ solve [3,1,2] [5] == 0
  print $ solve [1,1,2,2,3] [1,2] == 2
