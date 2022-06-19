-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_10_B/review/3388283/tyanon/Haskell
{-# OPTIONS_GHC -Wall #-}
import Control.Monad ( replicateM )
import Data.Array ( Array, listArray, array, (!) )

readInt :: String -> Int
readInt = read

calcDp :: Int -> Array Int Int -> Array Int Int -> Array (Int,Int) Int
calcDp n hs ws = dp where
  dp = array ((0,0),(n-1,n-1)) $ concatMap gen [1..n]
  gen 1 = [((i,i),0) | i<-[0..n-1]]
  gen k = [((i,i+k-1),f i k) | i<-[0..n-k]]
  f i k = minimum $ [g i k l | l<-[1..k-1]]
  g i k l = h1*w2*w1 + dp!(i,i+l-1) + dp!(i+l,i+k-1) where
    h1 = hs!i
    w1 = ws!(i+l-1)
    w2 = ws!(i+k-1)

main :: IO ()
main = do
  n  <- fmap readInt getLine
  ms <- replicateM n $ do
    [h,w] <- fmap (map readInt . words) getLine
    return (h,w)
  let (hs,ws) = (listArray (0,n-1) $ map fst ms, listArray (0,n-1) $ map snd ms)
  let dp  = calcDp n hs ws
  let ans = dp!(0,n-1)
  print ans
