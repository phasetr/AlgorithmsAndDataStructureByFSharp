{-
https://atcoder.jp/contests/agc017/submissions/1409115
-}
import Data.List.Split
main = mapM_ (print . solve) . chunksOf 2. map (map read . words) . lines =<< getContents
solve [[n, p], as] = 2^e * max (1-p) (2^o `div` 2)
  where [e,o] = map (length . flip filter as) [even,odd]
