-- https://atcoder.jp/contests/tessoku-book/submissions/37978637
import Control.Monad ( replicateM )
import Data.Bits ( Bits(xor) )
import Data.Bool ( bool )
import qualified Data.ByteString.Char8 as C
import Data.List ( unfoldr, foldl1' )

main :: IO ()
main = get >>= \(n:_) -> replicateM n get >>= putStrLn . bool "Second" "First" . sol

get :: IO [Int]
get = unfoldr (C.readInt . C.dropWhile (<'+')) <$> C.getLine

sol :: [[Int]] -> Bool
sol = (>0) . foldl1' xor . map pred . concat
