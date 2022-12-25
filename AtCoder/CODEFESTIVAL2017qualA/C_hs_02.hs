-- https://atcoder.jp/contests/code-festival-2017-quala/submissions/14458387
import Data.List ( group, sort )

main :: IO ()
main = do
  [h,w] <- map read . words <$> getLine
  as <- map length . group . sort . filter (/= '\n') <$> getContents
  putStrLn $ if solve h w as then "Yes" else "No"

solve h w as
  | odd h && odd w = s4 >= (h-1) * (w-1) `div` 4 && s1 == 1
  | even h && even w = all ((== 0) . (`mod` 4)) as
  | odd h && even w = s4 >= (h-1) * w `div` 4 && s1 == 0
  | even h && odd w = s4 >= h * (w-1) `div` 4 && s1 == 0
  where
    s4 = sum (map (`div` 4) as)
    s1 = sum (map (`mod` 2) as)
