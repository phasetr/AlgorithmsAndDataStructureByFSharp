-- https://atcoder.jp/contests/agc034/submissions/17495339
main :: IO ()
main = print . f 0 0 =<< getLine
f :: Num p => p -> p -> [Char] -> p
f i k ('B':'C':s) = f (i+k) k s
f i k (c:s) = f i (if c=='A' then k+1 else 0) s
f i _ _ = i
