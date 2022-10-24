-- https://atcoder.jp/contests/sumitrust2019/submissions/15675394
import Control.Monad ( foldM, replicateM )
import Data.Char ( digitToInt )
import Data.Maybe ( mapMaybe )
import qualified Data.Vector as V
import qualified Data.Set as S
main :: IO ()
main = print . solve =<< (getLine >> getLine)
solve :: String -> Int
solve s = length . mapMaybe f $ replicateM 3 [0..9] where
  ns = V.accum (flip S.insert) (V.replicate 10 S.empty) . (`zip` [0..]) . map digitToInt $ s
  f = foldM (\k i -> S.lookupGT k $ ns V.! i) (-1)
