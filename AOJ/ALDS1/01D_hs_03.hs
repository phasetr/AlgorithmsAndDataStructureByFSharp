-- http://judge.u-aizu.ac.jp/onlinejudge/description.jsp?id=ALDS1_1_D&lang=ja
-- http://judge.u-aizu.ac.jp/onlinejudge/review.jsp?rid=3386071#1
solve :: [Int] -> Int
solve a = maximum $ zipWith (-) (tail a) $ scanl1 min a

main :: IO ()
main = getLine >> getContents >>= print . solve . map read . words

test = do
  print $ solve [6,5,3,1,3,4,3] == 3
  print $ solve [3,4,3,2] == 1
