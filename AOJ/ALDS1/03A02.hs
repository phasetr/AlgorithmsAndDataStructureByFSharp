-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_3_A/review/3386134/tyanon/Haskell
main :: IO ()
main = getLine >>= print . head . foldl process [] . words

process :: [Int] -> String -> [Int]
process (r:l:xs) "+" = l+r : xs
process (r:l:xs) "-" = l-r : xs
process (r:l:xs) "*" = l*r : xs
process xs s         = read s : xs
