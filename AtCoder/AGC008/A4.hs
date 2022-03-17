{-
https://atcoder.jp/contests/agc008/submissions/17529974
-}
main :: IO ()
main = do
    [a, b] <- map read.words <$> getLine
    print $ solve a b

solve :: Int -> Int -> Int
solve a b = minimum $ concat
            [ [b - a | a <= b]
            , [b - (-a) + 1| (-a) <= b]
            , [(-b) - a + 1 | a <= (-b)]
            , [(-b) - (-a) + 2 | (-a) <= (-b)]
            ]
