-- https://atcoder.jp/contests/tenka1-2018/submissions/3490185
import Control.Monad ( replicateM )
import Data.List ( sort )

main :: IO ()
main = readLn >>= f where
  f n = replicateM n readLn >>= print . solve n

solve :: Int -> [Int] -> Int
solve n as
  | even n = 2 * (sum ys - sum xs) - head ys + last xs
  | otherwise = max s t
  where
    bs = sort as
    (xs, ys) = splitAt (n `div` 2) bs
    (us, vs) = splitAt (n `div` 2 + 1) bs

    s = 2 * (sum ys - sum xs) - sum (take 2 ys)
    t = 2 * (sum vs - sum us) + (sum . take 2 $ reverse us)
