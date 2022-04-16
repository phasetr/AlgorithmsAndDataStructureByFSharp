-- http://judge.u-aizu.ac.jp/onlinejudge/description.jsp?id=ALDS1_1_A&lang=ja
-- http://judge.u-aizu.ac.jp/onlinejudge/review.jsp?rid=2178139#1
main :: IO ()
main = do
  n <- readLn
  getLine >>=
    mapM_ (putStrLn . unwords . map show)
    . solve n 0
    . map read . words

solve :: Int -> Int -> [Int] -> [[Int]]
solve n i x
  | n == i    = []
  | otherwise =
    let k = x!!i
        t = drop (i+1) x
        h = insSort k $ take i x
        r = h ++ t
    in
      (r:solve n (i+1) r)
  where
    insSort :: Int -> [Int] -> [Int]
    insSort k [] = [k]
    insSort k (x:xs)
      | k <= x    = k:x:xs
      | otherwise = x:insSort k xs

test :: Bool
test = solve 6 0 [5,2,4,6,1,3] ==
  [[5,2,4,6,1,3]
  ,[2,5,4,6,1,3]
  ,[2,4,5,6,1,3]
  ,[2,4,5,6,1,3]
  ,[1,2,4,5,6,3]
  ,[1,2,3,4,5,6]]
  && solve 3 0 [1,2,3] ==
  [[1,2,3]
  ,[1,2,3]
  ,[1,2,3]]
