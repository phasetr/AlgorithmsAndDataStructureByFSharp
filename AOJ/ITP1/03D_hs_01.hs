-- http://judge.u-aizu.ac.jp/onlinejudge/description.jsp?id=ITP1_3_D&lang=ja
-- http://judge.u-aizu.ac.jp/onlinejudge/review.jsp?rid=1709762#1
main :: IO ()
main = getLine >>=
  putStrLn . show
  . (\[a, b, c] -> length [x | x <- [a..b], c `mod` x == 0])
  . map (read :: String -> Int) . words
