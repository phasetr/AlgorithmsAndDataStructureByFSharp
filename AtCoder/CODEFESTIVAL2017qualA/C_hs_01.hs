-- https://atcoder.jp/contests/code-festival-2017-quala/submissions/1693814
import Data.List ( group, sort )
import Data.Bool ( bool )

main = do
  [h,w] <- map read . words <$> getLine
  as <- sort . map length . group . sort . concat . lines <$> getContents
  let c1 = bool 0 1 $ odd h && odd w
      c2 = bool 0 (h `quot` 2) (odd w) + bool 0 (w `quot` 2) (odd h)
      as' = filter (/=0) $ map (`rem` 4) as
      r1 = length $ filter odd as'
      r2 = length as' - r1
  putStrLn $ bool "No" "Yes" (r1 == c1 && r2 <= c2)
