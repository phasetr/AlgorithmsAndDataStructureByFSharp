-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/NTL_1_C/review/1616092/cojna/Haskell
main :: IO ()
main = interact $ (++"\n").show.foldr(lcm.read)1.tail.words
