-- https://atcoder.jp/contests/abc064/submissions/15776119
main :: IO ()
main = interact $ f . last . lines;
f :: [Char] -> [Char]
f s | l <- scanl (+) 0 $ g <$> s, m <- minimum l = ('(' <$ [1..(negate m)]) ++ s ++ (')' <$ [1..last l-m])
g :: Num p => Char -> p
g c | c < ')' = 1
    | 0<1 = negate 1
g _ = error "not come here"
