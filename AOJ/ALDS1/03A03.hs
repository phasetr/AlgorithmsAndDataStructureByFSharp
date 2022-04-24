-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_3_A/review/2701858/satoshi3/Haskell
main :: IO ()
main = getContents >>= print . solve [] . words

solve :: [Int] -> [String] -> Int
solve cs [] = head cs
solve (a:b:cs) ("+":ys) = solve ((a+b):cs) ys
solve (a:b:cs) ("-":ys) = solve ((b-a):cs) ys
solve (a:b:cs) ("*":ys) = solve ((a*b):cs) ys
solve cs (y:ys)         = solve (read y:cs) ys
