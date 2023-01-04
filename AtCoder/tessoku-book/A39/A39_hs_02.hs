-- https://atcoder.jp/contests/tessoku-book/submissions/35450296
import Control.Monad ( replicateM )
import qualified Data.ByteString.Char8 as BS
import Data.Char ( isSpace )
import Data.List ( unfoldr )

import qualified Data.IntMap as IM

main :: IO ()
main = do
  [n] <- bsGetLnInts
  lrs <- replicateM n bsGetLnInts
  let ans = tba39 n lrs
  print ans

bsGetLnInts :: IO [Int]
bsGetLnInts = unfoldr (BS.readInt . BS.dropWhile isSpace) <$> BS.getLine

tba39 :: Int -> [[Int]] -> Int
tba39 n lrs = snd $ IM.findMax cmx where
  lrs1 = IM.assocs $ IM.fromListWith min [(l,r) | (l:r:_) <- lrs]
  cm0 = IM.singleton 0 0
  cmx = foldl step cm0 lrs1
  step cm (l,r)
    | c < d = cm
    | otherwise  = IM.insert r c1 cm1
    where
      Just (_,c) = IM.lookupLE l cm
      c1 = succ c
      Just (_,d) = IM.lookupLE r cm
      cm1 = delLow r c1 cm
  delLow r c cm =
    case IM.lookupGT r cm of
      Just (t,d) | c >= d -> delLow r c (IM.delete t cm)
      _other -> cm
