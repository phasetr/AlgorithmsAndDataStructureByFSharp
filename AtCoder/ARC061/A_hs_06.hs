-- https://atcoder.jp/contests/abc045/submissions/18412202
import Control.Monad ( replicateM )

main :: IO ()
main = do
  s <- getLine
  print $ solve s

solve :: String -> Int
solve s = sum $ do
  a <- replicateM (length s - 1) [0,1]
  return $ fst $ foldl f (0,0) $ zip (reverse s) $ 0 : a

f :: (Int, Int) -> (Char, Int) -> (Int, Int)
f (sum, count) (c, 0) = (sum + read [c] * 10 ^ count, count + 1)
f (sum, count) (c, 1) = (sum + read [c], 1)
f _ _ = error "not come here"
