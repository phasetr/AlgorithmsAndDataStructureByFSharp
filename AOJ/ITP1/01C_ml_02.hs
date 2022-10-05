-- http://judge.u-aizu.ac.jp/onlinejudge/description.jsp?id=ITP1_1_C&lang=ja
main :: IO ()
main = getLine >>= putStrLn . solve . map read . words

solve :: (Show a, Num a) => [a] -> [Char]
solve [a,b] = show (a*b) ++ " " ++ show (2*(a+b))
solve _ = error "not come here"
