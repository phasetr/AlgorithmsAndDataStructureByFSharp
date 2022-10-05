-- http://judge.u-aizu.ac.jp/onlinejudge/description.jsp?id=ITP1_1_C&lang=ja
main :: IO ()
main = do
  line <- getLine
  let a:b:_ = map read $ words line :: [Int]
  print $ show (a*b) ++ " " ++ show (2*(a+b))
  -- printf "%d %d\n" (a * b) (2 * (a + b))
