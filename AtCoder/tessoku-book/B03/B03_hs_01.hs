-- https://atcoder.jp/contests/tessoku-book/submissions/36746382
import Data.Bool ( bool )
import Data.List ( tails )

main :: IO ()
main = (getLine *> get) >>= put . sol

get :: IO [Integer]
get = map read . words <$> getLine

put :: [a] -> IO ()
put = putStrLn . bool "Yes" "No" . null

sol :: (Eq c, Num c) => [c] -> [(c, c, c)]
sol as = [(a,b,c) | (a:bs) <- tails as, (b:cs) <- tails bs, c <- cs, a+b+c==1000]
