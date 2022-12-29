-- https://atcoder.jp/contests/tessoku-book/submissions/37372358
import Data.Bool ( bool )
import qualified Data.ByteString.Char8 as C
import Data.List ( unfoldr )
import qualified Data.IntSet as S

main :: IO ()
main = sol <$> get <*> get <*> get <*> get <*> get >>= putStrLn

get :: IO [Int]
get = unfoldr (C.readInt . C.dropWhile (<'+')) <$> C.getLine

sol :: [Int] -> [Int] -> [Int] -> [Int] -> [S.Key] -> [Char]
sol [n,k] as bs cs ds =
  bool "Yes" "No" $ null [1| a <- as, b <- bs, a+b<k-2, c <- cs, a+b+c<k-1, (k-(a+b+c)) `S.member` s]
  where s = S.fromList ds
sol _ _ _ _ _ = error "not come here"
