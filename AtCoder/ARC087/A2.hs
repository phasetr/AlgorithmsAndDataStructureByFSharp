{-
https://atcoder.jp/contests/abc082/submissions/27600597
-}
import Data.IntMap.Strict (empty,foldrWithKey,insertWith)
import Data.IntSet.Internal (Key)

main :: IO ()
main = interact $ show . solve . fmap read . tail . words


solve :: [Key] -> Key
solve = foldrWithKey (\k l -> (+ if k>l then l else l-k)) 0
  . foldr (flip (insertWith (+)) 1) empty
