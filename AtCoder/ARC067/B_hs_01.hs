-- https://atcoder.jp/contests/abc052/submissions/11072894
main :: IO ()
main = interact $ show . sol . fmap get . lines

get :: String -> [Integer]
get = fmap read . words

sol :: (Num c, Ord c) => [[c]] -> c
sol [[n,a,b],xs] = sum . fmap (min b . (*a)) $ zipWith (-) (tail xs) xs
sol _ = error "not come here"
