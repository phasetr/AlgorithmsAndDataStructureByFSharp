-- https://atcoder.jp/contests/apc001/submissions/3699802
import Data.Char ( isSpace )
import Data.List ( unfoldr )
import qualified Data.ByteString.Char8 as B
main :: IO ()
main = B.interact $ B.pack . f . unfoldr (B.readInt . B.dropWhile isSpace)
f :: [Int] -> [Char]
f (n:abs) =if s1 <= st && s2 <= st then "Yes" else "No" where
  (as,bs) = splitAt n abs
  s1 = sum (zipWith (curry sol1) as bs)
  s2 = sum (zipWith (curry sol2) as bs)
  st = sum bs - sum as
f _ = error "not come here"
sol1 :: Integral p => (p, p) -> p
sol1 (a,b)
  | a<b = (b-a+1)`div`2
  | otherwise = 0
sol2 :: (Ord p, Num p) => (p, p) -> p
sol2 (a,b)
  | a>b = a-b
  | otherwise = 0
