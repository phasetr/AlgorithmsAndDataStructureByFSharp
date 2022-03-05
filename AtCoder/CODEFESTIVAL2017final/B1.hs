{-
https://atcoder.jp/contests/cf17-final/submissions/27927157
-}
import Data.List (group,sort)
main :: IO ()
main = do
  s <- getLine
  putStrLn $ solve s

{- F#のA1.fsxでは1以下を判定するために全ての差の絶対値を取っているが,
ここではソートしておいて最小値から他の数を引く形にしている.-}
solve :: String -> String
solve s = if b then "NO" else "YES"
  where
    ns = sort $ map length $ group $ sort s
    ns' | length ns == 2 = 0 : ns
        | length ns == 1 = 0 : 0 : ns
        | otherwise      = ns
    h = head ns'
    b = any ((>1) . (\x -> x - h)) ns

test :: IO ()
test = do
  print $ solve "abac" == "YES"
    && solve "aba" == "NO"
    && solve "babacccabab" == "YES"

