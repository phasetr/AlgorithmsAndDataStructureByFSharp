-- https://atcoder.jp/contests/tessoku-book/submissions/37404159
import qualified Data.ByteString.Char8 as C
import Data.List ( foldl', unfoldr )

main :: IO ()
main = (C.getLine *> get) >>= print . sol

get :: IO [Int]
get = unfoldr (C.readInt . C.dropWhile (<'+')) <$> C.getLine

sol :: (Num p, Ord p) => [p] -> p
sol (h:hs) = fst . snd $ foldl' f ((10^4,0),(0,h)) hs where
  f (s,t) h = (t,min (g s h) (g t h))
  g (c,h0) h = (abs (h-h0)+c,h)
sol [] = error "not come here"
