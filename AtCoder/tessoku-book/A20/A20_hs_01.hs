-- https://atcoder.jp/contests/tessoku-book/submissions/37467820
{-# LANGUAGE FlexibleContexts #-}
import Data.Bool ( bool )
import qualified Data.ByteString.Char8 as C
import Data.Vector.Generic ((!))
import qualified Data.Vector as V
import qualified Data.Vector.Unboxed as U

main :: IO ()
main = sol <$> get <*> get >>= print

get :: IO [Char]
get = C.unpack . C.filter (>'+') <$> C.getLine

sol :: String -> String -> Int
sol s0 t0 = dp!(n-1)!(m-1) where
  s = V.fromList s0
  t = U.fromList t0
  n = V.length s
  m = U.length t
  dp = V.postscanl' upd (U.replicate m 0) s :: V.Vector (U.Vector Int)
  upd :: U.Vector Int -> Char -> U.Vector Int
  upd u c = U.unfoldrN m (f u c) (0,0)
  f :: U.Vector Int -> Char -> (Int, Int) -> Maybe (Int, (Int, Int))
  f u c (n,i) = Just (n',(n',i+1)) where
    n' = if c==t!i
      then 1+bool (u!(i-1)) 0 (i==0)
      else max n (u!i)

test = do
  print dp
  print $ upd (U.replicate m 0) 'm'
  print $ V.scanl upd (U.replicate m 0) s
  -- print $ V.scanl (\u c -> U.unfoldr (f u c) (0,0)) (U.replicate m 0) s
  print 1
  where
    s = V.fromList "mynavi"
    t = U.fromList "kyoto"
    n = V.length s
    m = U.length t
    dp = V.postscanl' upd (U.replicate m 0) s :: V.Vector (U.Vector Int)

    upd :: U.Vector Int -> Char -> U.Vector Int
    upd u c = U.unfoldrN m (f u c) (0,0)

    f :: U.Vector Int -> Char -> (Int, Int) -> Maybe (Int, (Int, Int))
    f u c (n,i) = Just (n',(n',i+1)) where
      n' = if c==t!i
        then 1+bool (u!(i-1)) 0 (i==0)
        else max n (u!i)
