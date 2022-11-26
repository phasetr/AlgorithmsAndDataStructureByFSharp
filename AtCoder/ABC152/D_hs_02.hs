-- https://atcoder.jp/contests/abc152/submissions/18700241
import Control.Monad ( forM_ )
import Data.Char ( digitToInt )
import qualified Data.Vector.Unboxed as V
import qualified Data.Vector.Unboxed.Mutable as VM
main :: IO ()
main = print . solve =<< readLn
solve :: (Enum p, Num p, Show p) => p -> Int
solve n = V.sum $ V.create $ do
  c <- VM.replicate 100 (0::Int)
  forM_ [1..n]$ \i->do
    let s = show i
    VM.modify c succ (digitToInt(head s) + digitToInt (last s)*10)
  forM_[0..9]$ \i->
    forM_[i..9]$ \j->do
      a <- VM.read c (i*10+j)
      b <- VM.read c (j*10+i)
      VM.write c (i*10+j) (a*b)
      VM.write c (j*10+i) (a*b)
  return c
