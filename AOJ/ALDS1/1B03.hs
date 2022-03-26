-- http://judge.u-aizu.ac.jp/onlinejudge/description.jsp?id=ALDS1_1_B&lang=ja
-- http://judge.u-aizu.ac.jp/onlinejudge/review.jsp?rid=2116711#1
gcd' :: Integral a => a -> a -> a
gcd' x y =
  if x >= y
    then gcd'' x y
    else gcd'' y x
  where
    gcd'' a 0 = a
    gcd'' a b = gcd' b (a`mod`b)

main :: IO ()
main =
  getLine >>=
    print . (\[x,y] -> gcd' x y)
    . map read . words
