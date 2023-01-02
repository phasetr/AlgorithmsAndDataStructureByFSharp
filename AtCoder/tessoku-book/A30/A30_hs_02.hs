-- https://atcoder.jp/contests/tessoku-book/submissions/35001729
import Data.Maybe ( fromJust )
import qualified Data.ByteString.Char8 as BS
import qualified Data.Vector.Unboxed as VU
import qualified Data.Vector.Unboxed.Mutable as VUM
import qualified Data.Vector as V
import qualified Data.Vector.Mutable as VM
import qualified Data.Array.Unboxed as AU
import qualified Data.Array.ST as AM

readInt = fst . fromJust . BS.readInt
readIntList = map readInt . BS.words
getInt = readInt <$> BS.getLine
getIntList = readIntList <$> BS.getLine

main :: IO ()
main = do
  [n, r] <- getIntList
  print $ combMod n r

modBase :: Int
modBase = 10^9+7

modN :: Int -> Int
modN = flip mod modBase

plusMod :: Int -> Int -> Int
plusMod x y = modN $ x + y

minusMod :: Int -> Int -> Int
minusMod x y | x < y = modBase + x - y
             | otherwise = x - y

mulMod :: Int -> Int -> Int
mulMod x y = modN $ x * y

powerMod :: Integral a => Int -> a -> Int
powerMod x 0 = 1
powerMod x y
  | even y = mulMod t t
  | otherwise = mulMod x $ mulMod t t
  where t = powerMod x $ div y 2

invMod :: Int -> Int
invMod n = powerMod n $ modBase - 2

combMod :: Int -> Int -> Int
combMod n k | n - k < k = mulMod (foldr mulMod 1 [k+1..n]) . invMod $ foldr mulMod 1 [1..n-k]
            | otherwise = mulMod (foldr mulMod 1 [n-k+1..n]) . invMod $ foldr mulMod 1 [1..k]
