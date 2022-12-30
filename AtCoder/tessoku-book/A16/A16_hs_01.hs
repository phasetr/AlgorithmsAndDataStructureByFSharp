-- https://atcoder.jp/contests/tessoku-book/submissions/37385871
import qualified Data.ByteString.Char8 as C
import Data.List ( foldl', unfoldr )

main :: IO ()
main = sol <$> (C.getLine *> get) <*> get >>= print

get :: IO [Int]
get = unfoldr (C.readInt . C.dropWhile (<'+')) <$> C.getLine

sol :: (Ord a, Num a) => [a] -> [a] -> a
sol (a:as) bs = snd . foldl' (\(s,t) (a,b) -> (t, min (s+b) (t+a))) (0,a) $ zip as bs
sol _ _ = error "not come here"
