-- https://atcoder.jp/contests/tessoku-book/submissions/37265560
import qualified Data.ByteString.Char8 as C
import Data.List ( foldl', unfoldr, find )
import Data.Maybe ( fromMaybe )
import Data.Vector.Generic ((!))
import qualified Data.Vector.Unboxed as VU

main :: IO ()
main = sol <$> get <*> get >>= print

get :: IO [Int]
get = unfoldr (C.readInt . C.dropWhile (<'+')) <$> C.getLine

sol :: [Int] -> [Int] -> Int
sol [n,k] as = fst $ foldl' (\(s,l) i -> let r=f i l in (s+r-i-1,r)) (0,1) [1..n-1] where
  v = VU.fromListN (n+1) (0:as)
  f i l = fromMaybe (n+1) $ find ((k+v!i<) . (v!)) [l..n]
sol _ _ = error "not come here"
