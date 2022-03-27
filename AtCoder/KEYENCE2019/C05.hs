-- https://atcoder.jp/contests/keyence2019/submissions/4012288
import qualified Data.ByteString.Char8 as B
import Data.Maybe (fromJust)
import Data.List (findIndex,sort)
main :: IO ()
main = do
  B.getLine
  as <- map (fst. fromJust . B.readInteger) . B.words <$> B.getLine
  bs <- map (fst. fromJust . B.readInteger) . B.words <$> B.getLine
  let cs = zipWith max as bs
      x = length $ filter id $ zipWith (/=) as cs
      d = sum cs - sum as
      y = findIndex (>= d) $ scanl (+) 0 $ reverse $ sort $ zipWith (-) cs bs
  print $ maybe (-1) (x +) y
