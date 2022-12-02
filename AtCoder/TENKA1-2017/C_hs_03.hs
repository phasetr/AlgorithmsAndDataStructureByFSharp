-- https://atcoder.jp/contests/tenka1-2017/submissions/3221130
main :: IO ()
main = do
    n <- readLn
    putStrLn $ unwords $ map show $ solve n

solve :: Int -> [Int]
solve n = head
    [ [h, k, (n * h * k) `div` d]
    | h <- [1 .. 3500]
    , k <- [1 .. h]
    , let d = 4 * h * k - n * (k + h)
    , d > 0
    , (n * h * k) `mod` d == 0
    ]
