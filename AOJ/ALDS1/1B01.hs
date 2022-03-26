-- http://judge.u-aizu.ac.jp/onlinejudge/description.jsp?id=ALDS1_1_B&lang=ja
-- http://judge.u-aizu.ac.jp/onlinejudge/review.jsp?rid=2116711#1
gcd' :: Int -> Int -> Int
gcd' x 0 = x
gcd' x y = gcd' y (x `mod` y)

ans :: Int -> Int -> Int
ans x y =
  if x >= y
  then gcd' x y
  else gcd' y x

main :: IO ()
main =
  getLine >>=
    putStrLn . show
    . (\xs -> ans (xs!!0) (xs!!1))
    . map (read :: String -> Int) . words
