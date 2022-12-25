-- https://atcoder.jp/contests/code-festival-2017-quala/submissions/11472365
import Data.List ( group, sort )
import Data.Bool ( bool )
import Control.Monad ( replicateM )

main :: IO ()
main = do
  [h,w] <- map read . words <$> getLine
  a <- map length . group . sort . concat <$> replicateM h getLine
  putStrLn $ bool "No" "Yes" $ solve h w a

solve :: Integral b => Int -> Int -> [b] -> Bool
solve h w a
  | even h && even w = x == 0 && y == 0
  | even h && odd w = x == 0 && y <= div h 2
  | odd h && even w = x == 0 && y <= div w 2
  | odd h && odd w = x == 1 && y <= div (h+w) 2 - 1
  where
    x = length $ filter (==1) m4
    y = length $ filter (==2) m4
    m4 = map (`mod` 4) a
