{-
https://atcoder.jp/contests/abc137/submissions/25865432
-}
import Data.List (group,sort)
import Control.Monad (ap,replicateM)

main :: IO ()
main = readLn >>= flip replicateM getLine >>= print . solve

solve :: [String] -> Int
solve = sum . map ((`div`2) . ap (*) (-1+) . length) . group . sort . map sort
