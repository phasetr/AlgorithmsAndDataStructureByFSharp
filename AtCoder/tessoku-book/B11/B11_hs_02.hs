-- https://atcoder.jp/contests/tessoku-book/submissions/37132603
import qualified Data.ByteString.Char8 as C
import Data.List ( sort, unfoldr )
import Data.Vector.Generic ((!))
import Data.Vector.Unboxed (fromListN)

main :: IO ()
main = sol <$> readLn <*> get <*> getc >>= mapM_ print

get :: IO [Int]
get = unfoldr (C.readInt . C.dropWhile (<'+')) <$> C.getLine

getc :: IO [Int]
getc = unfoldr (C.readInt . C.dropWhile (<'+')) <$> C.getContents

sol n as (_:xs) = map (f 0 (n+1) . b) xs
  where
  v = fromListN (n+2) . (0:) $ sort (10^9:as)
  b x i = v!i<x
sol _ _ _ = error "not come here"

f :: Integral a => a -> a -> (a -> Bool) -> a
f l r p
  | l >= r    = l
  | p m       = f m r p
  | otherwise = f l (m-1) p
  where m = (l+r+1) `div` 2
