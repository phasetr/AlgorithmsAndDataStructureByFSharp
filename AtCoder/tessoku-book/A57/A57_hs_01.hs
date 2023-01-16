-- https://atcoder.jp/contests/tessoku-book/submissions/35626927
import Control.Monad ( replicateM_ )
import qualified Data.ByteString.Char8 as BS
import Data.Char ( isSpace )
import Data.List ( unfoldr )

import qualified Data.Vector.Unboxed as UV

main :: IO ()
main = do
  [n,q] <- bsGetLnInts
  as <- bsGetLnInts
  let dat = tba57p n as
  replicateM_ q $ do
    [x,y] <- bsGetLnInts
    let ans = tba57 dat x y
    print ans

bsGetLnInts :: IO [Int]
bsGetLnInts =  unfoldr (BS.readInt . BS.dropWhile isSpace) <$> BS.getLine

-- 1,2,4...回の移動先の表リスト
tba57p :: Int -> [Int] -> [UV.Vector Int]
tba57p n as = iterate twice $ UV.fromList (0:as) where
  twice av = UV.fromList $ map ((av UV.!) . (av UV.!)) [0..n]

tba57 :: Integral a => [UV.Vector Int] -> Int -> a -> Int
tba57 vs x y = foldl (flip (UV.!)) x [v | (True, v) <- zip bs vs] where
  bs = map odd $ takeWhile (0 <) $ iterate (flip div 2) y
