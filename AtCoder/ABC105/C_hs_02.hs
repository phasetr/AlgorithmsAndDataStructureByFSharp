-- https://atcoder.jp/contests/abc105/submissions/3139310
cvt :: (Show a, Integral a) => a -> [Char]
cvt n = if n==0 then "0" else csub n

csub :: (Show a, Integral a) => a -> [Char]
csub 0 = ""
csub n = let (q, r) = divMod n 2 in csub (-q) ++ show r

main :: IO ()
main = readLn >>= putStrLn . cvt
