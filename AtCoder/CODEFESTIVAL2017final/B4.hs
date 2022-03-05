{-
https://atcoder.jp/contests/cf17-final/submissions/10320782
-}
import Control.Monad (guard)
import Data.List (sort)
import Data.Maybe (fromMaybe)

main :: IO ()
main = getLine >>= putStrLn . solve

solve :: String -> String
solve = fromMaybe "NO" . (<$) "YES" . guard . f where
  f s = mx - mn <= 1 where
    [mn, _, mx] = sort $ map (length . ($s) . filter . (==)) "abc"

test :: IO ()
test = do
  print $ solve "abac" == "YES"
    && solve "aba" == "NO"
    && solve "babacccabab" == "YES"
