{-
https://atcoder.jp/contests/agc039/submissions/27319071
-}
import Data.List (group)

solve :: Eq a => [a] -> Int -> Int
solve s k = if (length . group) s == 1
  then length s * k `div` 2
  else normal + middle * (k-1)
  where
    normal = sum $ map ((`div` 2).length) $ group s
    -- middle pattern
    h = head s
    pre = takeWhile (==h) s
    post = dropWhile (==h) s
    s' = post ++ pre
    middle = sum $ map ((`div` 2).length) $ group s'

main :: IO ()
main = do
  s <- getLine
  k <- readLn
  print $ solve s k
