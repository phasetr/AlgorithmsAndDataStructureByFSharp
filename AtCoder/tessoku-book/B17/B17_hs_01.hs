-- https://atcoder.jp/contests/tessoku-book/submissions/37402500
import qualified Data.ByteString.Char8 as C
import Data.List ( foldl', unfoldr )

main :: IO ()
main = (C.getLine *> get) >>= put . sol

get :: IO [Int]
get = unfoldr (C.readInt . C.dropWhile (<'+')) <$> C.getLine

put :: [Integer] -> IO ()
put = ((>>) . print . length) <*> (putStrLn . unwords . fmap show)

sol :: (Num a1, Num a2, Ord a1, Ord a2, Enum a2) => [a1] -> [a2]
sol (h:hs) = reverse . snd . snd . foldl' f (((10^4,0),[]),((0,h),[1])) $ zip hs [2..] where
  f (s,t) (h,p) = (t,min (g s (h,p)) (g t (h,p)))
  g ((c,h0),ps) (h,p) = ((abs (h-h0)+c,h),p:ps)
sol [] = error "not come here"
