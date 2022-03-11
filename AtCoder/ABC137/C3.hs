{-
https://atcoder.jp/contests/abc137/submissions/11946614
-}
import Control.Monad (replicateM)
import Data.Functor ((<&>))
import Data.List (group,sort)

main :: IO ()
main = do
  --n <- getLine >>= return . (read :: String -> Int)
  n <- getLine <&> read
  s <- replicateM n getLine
  print $ solve s

solve :: [String] -> Int
solve = sum . map ((\x -> x*(x-1) `div` 2) . length) . group . sort . map sort
