-- https://atcoder.jp/contests/diverta2019/submissions/13466331
import Control.Monad ( replicateM )
import Data.List ( isPrefixOf, tails )

main :: IO ()
main = do
  n <- readLn
  ss <- replicateM n getLine
  let ab = sum $ map  (length . filter ("AB" `isPrefixOf`) . tails) ss
      a = length $ filter (\x -> last x == 'A' && head x /= 'B') ss
      b = length $ filter (\x -> last x /= 'A' && head x == 'B') ss
      ba = length $ filter (\x -> last x == 'A' && head x == 'B') ss
      ans | ba == 0 = ab + min a b
          | a == 0 && b == 0 = ab + ba - 1
          | otherwise = ab + ba + min a b
  print ans
