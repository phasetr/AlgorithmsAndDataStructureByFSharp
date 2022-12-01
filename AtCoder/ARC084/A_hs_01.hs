-- https://atcoder.jp/contests/abc077/submissions/17594768
import qualified Data.ByteString.Char8 as C
import Data.List ( unfoldr, sort )
import qualified Data.Vector.Unboxed as U
import Data.Vector.Unboxed ((!))

main :: IO ()
main = sol <$> readLn <*> get <*> get <*> get >>= print

get :: IO (U.Vector Int)
get = U.fromList . sort . unfoldr (C.readInt . C.dropWhile (<'+')) <$> C.getLine

sol :: Int -> U.Vector Int -> U.Vector Int -> U.Vector Int -> Int
sol n as bs cs = U.sum $ U.map f bs where
  f k = g k*(n - h k)
  g k = bsearch 0 (n+1) $ (<k) . (a!)
  h k = bsearch 0 (n+1) $ (<=k) . (c!)
  a = U.cons 0 $ U.snoc as m
  c = U.cons 0 $ U.snoc cs m
  m = 10^9+1

bsearch :: Int -> Int -> (Int -> Bool) -> Int
bsearch l r p
  | l >= r    = l
  | p m       = bsearch m r p
  | otherwise = bsearch l (m-1) p
  where m = (l+r+1) `div` 2
