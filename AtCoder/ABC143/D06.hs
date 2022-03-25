{-
https://atcoder.jp/contests/abc143/submissions/28779419
-}
import Data.List (sort,tails)
import qualified Data.IntMap as IM

main :: IO ()
main = do
  getLine
  ls <- map read . words <$> getLine
  print $ compute ls

compute :: [Int] -> Int
compute ls = sum
  [ max 0 (j - i)
  | (a,_):lis1 <- tails lis  -- 最も短い辺
  , (b,i) <- lis1            -- 次の辺
  , let Just (_,j) = IM.lookupLT (a+b) m -- a+b未満の最大値の背番号
  ]
  where
    lis = zip (sort ls) [1..]
    m = IM.fromList lis
