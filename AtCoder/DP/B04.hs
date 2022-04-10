-- https://atcoder.jp/contests/dp/submissions/25090531
import Data.Char (isSpace)
import Data.List (foldl',unfoldr)
import qualified Data.ByteString.Char8 as B
import qualified Data.IntMap as IM

main = do
  [_,k] <- unfoldr (B.readInt . B.dropWhile isSpace) <$> B.getLine
  hs <- unfoldr (B.readInt . B.dropWhile isSpace) <$> B.getLine
  print $ solve k hs

solve :: Int -> [Int] -> Int
solve k (h0:hs) = cEnd where
  cEnd = snd $ head $ foldl' step s0 hs
  step l h = (h,c) : l where
    c = minimum $ map (\(hi,ci) -> ci + abs (hi - h)) $ take k l
  s0 = [(h0,0)]
solve _ _ = undefined
