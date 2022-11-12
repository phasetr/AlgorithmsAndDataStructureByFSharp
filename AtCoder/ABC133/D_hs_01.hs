-- https://atcoder.jp/contests/abc133/submissions/9857855
main :: IO ()
main = interact $ unwords . init . f . map read . words
f :: (Show a, Num a) => [a] -> [String]
f (_:l) = show <$> scanr ((-) . (*2)) (foldr1 (-) l) l
f _ = error "not come here"
