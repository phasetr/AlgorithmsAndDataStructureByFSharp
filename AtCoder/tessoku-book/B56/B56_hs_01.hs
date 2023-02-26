-- https://atcoder.jp/contests/tessoku-book/submissions/35626353
import Control.Monad
import qualified Data.ByteString.Char8 as BS
import Data.Char ( isSpace )
import Data.List ( unfoldr )

import qualified Data.Vector.Unboxed as UV

main :: IO ()
main = do
  [n,q] <- bsGetLnInts
  s <- BS.getLine
  let dat = tbb56p n s
  replicateM_ q $ do
    [l,r] <- bsGetLnInts
    let ans = tbb56 n s dat l r
    putStrLn $ if ans then "Yes" else "No"

bsGetLnInts :: IO [Int]
bsGetLnInts = BS.getLine >>= return . unfoldr (BS.readInt . BS.dropWhile isSpace)

modBase = 1000000007
reg x = mod x modBase
base = 29

-- 文字列を26進数として、先頭からn文字めまでの値をmodで、おまけに26^nも、さらに後ろからも
tbb56p :: Int
-> BS.ByteString -> (UV.Vector Int, UV.Vector Int, UV.Vector Int)
tbb56p n s = (bases, hashs, rhashs)
  where
    bases = UV.fromList $ take (succ n) $ iterate (reg . (base *)) 1
    hashs = UV.fromList $ scanl step 0 $ BS.unpack s
    step acc c = reg $ acc * base + fromEnum c - smallA
    smallA = fromEnum 'a'
    rhashs = UV.fromList $ scanl step 0 $ map (BS.index s) [n-1, n-2 .. 0]

tbb56 :: Int
  -> BS.ByteString
  -> (UV.Vector Int, UV.Vector Int, UV.Vector Int)
  -> Int
  -> Int
  -> Bool
tbb56 n s (bases, hashs, rhashs) l r = v1 == v2 where
  h hf l r = reg $ hf r - hf (pred l) * bases UV.! (r - l + 1)
  v1 = h (hashs UV.!) l r
  n1 = succ n
  v2 = h (rhashs UV.!) (n1 - r) (n1 - l)
  v3 = and
    [ BS.index s (pred i) == BS.index s (pred j)
    | (i,j) <- takeWhile (uncurry (<)) $ zip [l..] [r,pred r..]]
