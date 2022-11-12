-- https://atcoder.jp/contests/abc050/submissions/2854710
import Data.List
import qualified Data.ByteString.Char8 as B

main :: IO ()
main = do
  n <- readLn
  as <- sort . unfoldr (B.readInt . B.dropWhile (== ' ')) <$> B.getLine
  print $ if even n then chke as else chko as

chke :: [Int] -> Integer
chke = chk 1 1
chko :: (Num t, Integral p, Eq t) => [t] -> p
chko (a:as)
  | a /= 0 = 0
  | otherwise   = chk 1 2 as
chko _ = error "not come here"

chk :: (Integral t1, Num t2, Eq t2) => t1 -> t2 -> [t2] -> t1
chk p _ [] = p
chk p n (a:b:as)
  | a==n && b==n = chk ((p*2) `mod` 1000000007) (n+2) as
  | otherwise = 0
chk _ _ _ = error "not come here"
