-- https://atcoder.jp/contests/tessoku-book/submissions/37440801
import Control.Monad ( join, replicateM )
import qualified Data.ByteString.Char8 as C
import Data.List ( foldl', unfoldr )

main :: IO ()
main = join $ sub <$> get

sub :: [Int] -> IO ()
sub [n,k] = replicateM n get >>= print . sol k
sub _ = error "not come here"

get :: IO [Int]
get = unfoldr (C.readInt . C.dropWhile (<'+')) <$> C.getLine

sol :: Foldable t => Int -> t [Int] -> Int
sol k wv = snd . head $ foldl' f [(k,0)] wv where
  f ts [w,v] = mono . merge ts . filter ((>=0) . fst) $ map (\(wa,va) -> (wa-w, va+v)) ts
  f _ _ = error "not come here"

merge :: (Ord a, Ord b) => [(a, b)] -> [(a, b)] -> [(a, b)]
merge [] t = t
merge t [] = t
merge t1@((w1,v1):wv1) t2@((w2,v2):wv2) = case compare w1 w2 of
  LT -> (w1,v1):merge wv1 t2
  EQ -> (w1,max v1 v2):merge wv1 wv2
  GT -> (w2,v2):merge t1 wv2

mono :: [(a, Int)] -> [(a, Int)]
mono = foldr f [] where
  f t [] = [t]
  f t@(_,v1) ts@((_,v2):_)
    | v1>v2     = t:ts
    | otherwise = ts
