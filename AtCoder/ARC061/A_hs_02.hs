-- https://atcoder.jp/contests/abc045/submissions/9713098
import Data.Char ( isDigit )
main :: IO ()
main = interact $ show . sol . get

get :: [Char] -> [Integer]
get = fmap (read . (:[])) . filter isDigit

sol :: [Integer] -> Integer
sol = f =<< length

f :: (Integral a, Integral t) => t -> [a] -> a
f 1 [x] = x
f n (x:xs) = x*(4*10^(n-1) + 5*10^(n-2) - 2^(n-2)) `div` 4 + 2*f (n-1) xs
f _ _ = error "not come here"
