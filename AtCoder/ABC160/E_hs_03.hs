-- https://atcoder.jp/contests/abc160/submissions/30956243
import qualified Data.ByteString.Char8 as BS
import Data.Char ( isSpace )
import Data.Functor ( (<&>) )
import Data.List ( sort, sortBy, unfoldr )

main :: IO ()
main = do
  [x,y,a,b,c] <- bsGetLnInts
  ps <- bsGetLnInts
  qs <- bsGetLnInts
  rs <- bsGetLnInts
  print $ abc160e x y a b c ps qs rs

bsGetLnInts :: IO [Int]
bsGetLnInts = BS.getLine <&> unfoldr (BS.readInt . BS.dropWhile isSpace)

abc160e :: Int -> Int -> Int -> Int -> Int -> [Int] -> [Int] -> [Int] -> Int
abc160e x y a b c ps qs rs = loop score0 pqs rs1 where
  ps1 = drop (a - x) $ sort ps
  qs1 = drop (b - y) $ sort qs
  score0 = sum ps1 + sum qs1
  pqs = sort (ps1 ++ qs1)
  rs1 = sortBy (flip compare) rs

loop :: (Ord p, Num p) => p -> [p] -> [p] -> p
loop sc (p:ps) (r:rs)
  | r > p = loop (sc + r - p) ps rs
loop sc _ _ = sc
