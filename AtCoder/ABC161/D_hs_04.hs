-- https://atcoder.jp/contests/abc161/submissions/15790969
import Control.Monad ( guard )

lunlunNum :: [Int]
lunlunNum = [1..9] ++ (lunlunNum >>= lunlunGen)

lunlunGen :: Int -> [Int]
lunlunGen x = do
  let d = x `mod` 10
  t <- [d - 1, d, d + 1]
  guard $ t >= 0 && t <= 9
  return $ 10 * x + t

main :: IO ()
main = do
  n <- readLn
  print $ lunlunNum !! (n - 1)
