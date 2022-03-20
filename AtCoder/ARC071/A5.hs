{-
https://atcoder.jp/contests/abc058/submissions/1866281
-}
import Data.List ((\\),sort)
main :: IO ()
main = interact $ (++"\n") . sort . foldl1 (\x y -> x \\ (x \\ y)) . tail . lines
