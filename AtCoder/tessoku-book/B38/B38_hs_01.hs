-- https://atcoder.jp/contests/tessoku-book/submissions/38310277
import qualified Data.ByteString.Char8 as C

main :: IO ()
main = (C.getLine *> C.getLine) >>= print . sol

sol :: C.ByteString -> Int
sol s = let ls = map C.length (C.group s) in if C.head s=='A' then f ls else g ls

f :: Integral a => [a] -> a
f [a] = s (a+1)
f (a:b:ls) = s a + 1 + max a b + g (b-1:ls)
f _ = error "not come here"

g :: Integral a => [a] -> a
g [b] = s (b+1)
g (b:a:ls) = s (b+1) - 1 + f (a:ls)
g _ = error "not come here"

s :: Integral a => a -> a
s n = n*(n+1) `div` 2
