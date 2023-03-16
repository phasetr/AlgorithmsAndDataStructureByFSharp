-- https://atcoder.jp/contests/tessoku-book/submissions/36187033
import qualified Data.ByteString.Char8 as BS
import Data.Char ( isSpace )
import Data.List ( unfoldr )

import qualified Data.IntMap as IM

main :: IO ()
main = do
  [n,p] <- bsGetLnInts
  as <- bsGetLnInts
  let ans = tbc13 n p as
  print ans

bsGetLnInts :: IO [Int]
bsGetLnInts = BS.getLine >>= return . unfoldr (BS.readInt . BS.dropWhile isSpace)

tbc13 :: Int -> Int -> [Int] -> Int
tbc13 n 0 as = div (n * pred n - cntNZ * pred cntNZ) 2 where
  cntNZ = length $ filter ((0 /=) . reg) as
tbc13 n p as = sum $ map f $ IM.assocs cnt where
  cnt = IM.fromListWith (+) [(mod a modBase, 1) | a <- as]
  f (a, c) =
    case compare a b of
      LT -> c * IM.findWithDefault 0 b cnt
      EQ -> div (c * pred c) 2
      GT -> 0
    where b = mul p (modRecip a)

modBase :: Int
modBase = 1000000007
reg :: Int -> Int
reg x = mod x modBase
mul :: Int -> Int -> Int
mul x y = reg (x * y)
modRecip :: Int -> Int
modRecip a = u where
  (_,_,u,_) = until stop step (a, modBase, 1, 0)
  step (a,b,u,v) = let t = div a b in (b, a - t * b, v, u - t * v)
  stop (_,b,_,_) = b == 0
