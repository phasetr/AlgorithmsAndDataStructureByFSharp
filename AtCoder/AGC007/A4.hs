{-
https://atcoder.jp/contests/agc007/submissions/17183789
-}
import Data.Bool (bool)
main :: IO ()
main = putStrLn . bool "Impossible" "Possible" =<< f . map read . words =<<getLine

f :: [Int] -> IO Bool
f [h,w] = (== h+w-1) . length . filter (=='#') <$> getContents
f _ = error "not come here"
