{-
https://atcoder.jp/contests/keyence2019/submissions/4012201
-}
import Data.List (findIndex,sort)
main :: IO ()
main = do
  getLine
  as <- map read . words <$> getLine
  bs <- map read . words <$> getLine
  let cs = zipWith max as bs
      x = length $ filter id $ zipWith (/=) as cs
      d = sum cs - sum as
      y = findIndex (>= d) $ scanl (+) 0 $ reverse $ sort $ zipWith (-) cs bs
  print $ maybe (-1) (x +) y
