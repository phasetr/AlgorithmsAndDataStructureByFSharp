-- https://atcoder.jp/contests/code-festival-2016-qualb/submissions/3211298
-- a, b を減算していくという発想がなかったので参考用にメモ
import           Control.Monad

main :: IO ()
main = do
    [_, a, b] <- map read . words <$> getLine
    s         <- getLine
    putStrLn $ solve a b s

solve :: Int -> Int -> String -> String
solve a b []       = ""
solve a b (c : cs) = case c of
    'a' | a + b > 0 -> "Yes\n" ++ solve (a - 1) b cs
        | otherwise -> "No\n" ++ solve a b cs
    'b' | a + b > 0 && b > 0 -> "Yes\n" ++ solve a (b - 1) cs
        | otherwise          -> "No\n" ++ solve a b cs
    'c' -> "No\n" ++ solve a b cs
