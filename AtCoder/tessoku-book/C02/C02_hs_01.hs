-- https://atcoder.jp/contests/tessoku-book/submissions/35952253
import Data.List ( sortBy )

main :: IO ()
main = getLine >> getLine >>= print . sum . take 2 . sortBy (flip compare) . map read . words
