-- http://judge.u-aizu.ac.jp/onlinejudge/description.jsp?id=ALDS1_1_A&lang=ja
-- http://judge.u-aizu.ac.jp/onlinejudge/review.jsp?rid=1703447#1
import Data.List ( inits, sort, tails )
main :: IO ()
main =
  getLine >> getContents >>=
    mapM_ (putStrLn . unwords . map show) . solve
    . map read . words

solve :: [Int] -> [[Int]]
solve = tail . (zipWith (++) <$> map sort . inits <*> tails)
test :: IO ()
test = do
  print $ solve [5,2,4,6,1,3] == [[5,2,4,6,1,3],[2,5,4,6,1,3],[2,4,5,6,1,3],[2,4,5,6,1,3],[1,2,4,5,6,3],[1,2,3,4,5,6]]
  print $ solve [1,2,3] == [[1,2,3],[1,2,3],[1,2,3]]
