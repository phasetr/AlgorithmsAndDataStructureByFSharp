{-
https://atcoder.jp/contests/agc007/submissions/19514646
-}
import Data.Bool (bool)

main :: IO ()
main = do
  [h,w] <- map read . words <$> getLine
  xs <- getContents
  putStrLn (bool "Impossible" "Possible" (length (filter (== '#') xs) == (h+w-1)))
