{-
https://atcoder.jp/contests/abc047/submissions/16026060
-}
import Data.List (group)
main :: IO ()
main = getLine >>= print . pred . length . group
