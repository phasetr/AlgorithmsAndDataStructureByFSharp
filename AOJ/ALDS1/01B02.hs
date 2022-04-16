-- http://judge.u-aizu.ac.jp/onlinejudge/description.jsp?id=ALDS1_1_B&lang=ja
-- http://judge.u-aizu.ac.jp/onlinejudge/review.jsp?rid=2116711#1
main :: IO ()
main = getLine
  >>= print . solve . (\[x,y] -> (x,y)) . map read . words
solve :: Integral t => (t,t) -> t
solve (x,y) = if x >= y then gcd' x y else gcd' y x
  where gcd' x y = if y==0 then x else gcd' y (x `mod` y)

test :: IO ()
test = print $ solve (147,105) == 21
