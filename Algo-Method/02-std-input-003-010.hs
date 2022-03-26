{-
https://algo-method.com/tasks/62
-}
import Control.Monad (replicateM)
main :: IO ()
main = (getLine >>= (`replicateM` getLine) . read)
  >>= putStr
  . (\(l,r) -> if l<r then "right" else if r<l then "left" else "same")
  . foldl (\ (l,r) s -> if s=="left" then (l+1,r) else (l,r+1)) (0,0)

solve1 = getLine >> getContents
  >>= putStrLn . f . (map length) . group . sort . lines where
  f [l,r]
    |l > r = "left"
    |l < r = "right"
    |otherwise = "same"
