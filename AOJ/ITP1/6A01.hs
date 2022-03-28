-- https://onlinejudge.u-aizu.ac.jp/courses/lesson/2/ITP1/all/ITP1_6_A
main :: IO ()
main = getLine >> getLine >>= putStrLn . unwords . reverse . words
