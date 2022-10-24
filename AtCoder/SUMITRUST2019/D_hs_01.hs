-- https://atcoder.jp/contests/sumitrust2019/submissions/12257814
import Data.List ( isSubsequenceOf )
import Control.Monad ( replicateM )
main :: IO ()
main = getLine >> getLine >>= print.solve
solve :: String -> Int
solve s = length
  $ filter (`isSubsequenceOf` s)
  $ replicateM 3 ['0'..'9']
