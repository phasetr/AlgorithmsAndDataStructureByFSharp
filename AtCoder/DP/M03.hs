-- https://atcoder.jp/contests/dp/submissions/20027112
import Control.Monad
import qualified Data.ByteString.Char8 as C
import Data.Vector.Unboxed
import Prelude hiding (replicate)

main :: IO ()
main = get 2 >>= \v -> get (v!0) >>= print . solve (v!1) where
  get n = unfoldrN n (C.readInt . C.dropWhile (<'+')) <$> C.getLine

solve :: Int -> Vector Int -> Int
solve k = (!k) . foldl' f (cons 1 $ replicate k 0) where
  p = 10^9+7
  add x y = (x+y) `mod` p
  sub x y = (x-y) `mod` p

  f s i = scanl' g 1 (generate k succ) where
    g t j = add t (s!j) `sub` if j<i+1 then 0 else s!(j-i-1)
