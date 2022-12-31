-- https://atcoder.jp/contests/tessoku-book/submissions/37421867
import Data.Bool ( bool )
import qualified Data.ByteString.Char8 as C
import qualified Data.IntSet as S
import Data.List ( unfoldr )

main :: IO ()
main = sol <$> get <*> get >>= putStrLn

get :: IO [Int]
get = unfoldr (C.readInt . C.dropWhile (<'+')) <$> C.getLine

sol :: [S.Key] -> [S.Key] -> [Char]
sol [_,k] (a:as) = f (S.singleton a) as where
  f s as
    | S.member k s  = "Yes"
    | null as       = "No"
    | otherwise     = f s' (tail as)
    where
      a = head as
      s' = S.foldl' g s s
      g s i = let t = bool (S.insert a s) s (k<a) in bool (S.insert (i+a) t) t (k<i+a)
sol _ _ = error "not come here"
