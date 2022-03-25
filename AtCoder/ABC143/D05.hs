{-
https://atcoder.jp/contests/abc143/submissions/8122984
-}
import Data.List (sort)
import Data.Functor ((<&>))
f :: Int -> [Int] -> [Int] -> Int -> Int -> Int
f a [] _ _ _ = 0
f a _ [] _ _ = 0
f a (x:xs) (y:ys) m n
    | (a + x) > y = n - m + f a (x:xs) ys m (n + 1)
    | m + 1  == n = f a (x:xs) ys m (n + 1)
    | otherwise = f a xs (y:ys) (m + 1) n

g :: [Int] -> Int
g (a:(x:xs)) = f a (x:xs) xs 0 1 + g (x:xs)
g _ = 0

main :: IO ()
main = do
    getLine
    x <- getLine <&> sort . map (read :: String -> Int) . words
    print $ g x
