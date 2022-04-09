-- https://atcoder.jp/contests/dp/submissions/28329244
import Data.Array (listArray,(!))

solve :: [Int] -> Int
solve xs = (!n) $ loeb $ listArray (1, n) $ map f [1..n] where
  n = length xs
  xa = listArray (1, n) xs
  f 1 _  = 0
  f 2 _  = abs (xa!2 - xa!1)
  f i dp = jump 1 `min` jump 2 where
    jump j = abs (xa!i - xa!(i - j)) + dp!(i - j)

loeb :: Functor f => f (f a -> a) -> f a
loeb x = let y = fmap ($ y) x in y

main :: IO ()
main = getLine >> getLine >>= print . solve . map read . words
