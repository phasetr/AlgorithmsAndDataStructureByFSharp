-- https://atcoder.jp/contests/tessoku-book/submissions/38162887
import qualified Data.ByteString.Char8 as C
import Data.Bool ( bool )
import Data.List ( unfoldr )

main :: IO ()
main = sol <$> get <*> C.getLine >>= putStrLn . bool "No" "Yes"

get :: IO [Int]
get = unfoldr (C.readInt . C.dropWhile (<'+')) <$> C.getLine

sol :: [Int] -> C.ByteString -> Bool
sol [n,k] s = k<=n && even (k-C.count '1' s)
sol _ _ = error "not come here"
