-- https://atcoder.jp/contests/tessoku-book/submissions/37375071
import Data.Bool ( bool )
import qualified Data.ByteString.Char8 as C
import Data.List ( subsequences, unfoldr )
import qualified Data.IntSet as S

main :: IO ()
main = sol <$> get <*> get >>= putStrLn

get :: IO [Int]
get = unfoldr (C.readInt . C.dropWhile (<'+')) <$> C.getLine

sol :: [S.Key] -> [S.Key] -> [Char]
sol [n,k] as = bool "No" "Yes" . any ((\c -> (k-c) `S.member` s) . sum) $ subsequences cs where
  (bs,cs) = splitAt (n `div` 2) as
  s = S.fromList . map sum $ subsequences bs
sol _ _ = error "not come here"
