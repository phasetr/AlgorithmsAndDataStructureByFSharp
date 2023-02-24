-- https://atcoder.jp/contests/tessoku-book/submissions/35518757
main :: IO ()
main = getLine >>= putStrLn . b2yn . (0 ==) . sum . map read . words

b2yn :: Bool -> [Char]
b2yn True = "Yes"
b2yn _    = "No"
