-- http://judge.u-aizu.ac.jp/onlinejudge/description.jsp?id=ALDS1_1_C&lang=ja
-- http://judge.u-aizu.ac.jp/onlinejudge/review.jsp?rid=2407232#1
main :: IO()
main = getContents >>= print . solve. map read . lines
solve :: [Integer] -> Int
solve = length . filter (==True) . map isPrime where
  isPrime x = all ((/= 0) . mod x) [2..y]
    where y = (floor . sqrt . realToFrac) x
test :: IO ()
test = print $ solve [6,2,3,4,5,6,7]
