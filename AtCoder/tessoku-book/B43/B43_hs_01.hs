-- https://atcoder.jp/contests/tessoku-book/submissions/38711319
import qualified Data.ByteString.Char8 as C
import Data.List ( unfoldr )
import qualified Data.Vector.Unboxed as U

main :: IO ()
main = sol <$> get <*> get >>= mapM_ print

get :: IO [Int]
get = unfoldr (C.readInt . C.dropWhile (<'+')) <$> C.getLine

sol :: [Int] -> [Int] -> [Int]
sol [n,m] as = tail . U.toList . U.accum (-) (U.replicate (n+1) m) . zip as $ repeat 1
sol _ _ = error "not come here"
