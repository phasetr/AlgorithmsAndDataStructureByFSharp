-- https://atcoder.jp/contests/tessoku-book/submissions/37400298
import qualified Data.ByteString.Char8 as C
import Data.List ( foldl', unfoldr )

main :: IO ()
main = sol <$> (C.getLine *> get) <*> get >>= put

get :: IO [Int]
get = unfoldr (C.readInt . C.dropWhile (<'+')) <$> C.getLine

put :: [Integer] -> IO ()
put = ((>>) . print . length) <*> (putStrLn . unwords . fmap show)

sol :: (Ord a1, Num a1, Num a2, Enum a2) => [a1] -> [a1] -> [a2]
sol (a:as) bs = reverse . snd . snd . foldl' f ((0,[1]),(a,[2,1])) $ zip3 as bs [3..] where
  f ((s,ss),(t,ts)) (a,b,i) = ((t,ts),if s+b < t+a then (s+b,i:ss) else (t+a,i:ts))
sol _ _ = error "not come here"
