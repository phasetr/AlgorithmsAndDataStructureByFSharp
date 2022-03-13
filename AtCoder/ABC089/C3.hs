{-
https://atcoder.jp/contests/abc089/submissions/15360662
-}
import Data.Bits (Bits(popCount,testBit))
import Data.List (elemIndex)
import Data.Maybe (mapMaybe)
import qualified Data.ByteString.Char8 as B
import qualified Data.Vector.Unboxed as V

main :: IO ()
main = do
  n <- fmap (read::String -> Int) getLine
  ss <- fmap B.lines B.getContents
  print $ solve ss

solve :: [B.ByteString] -> Int
solve =
  f . V.accum (+) (V.replicate 5 0)
  . map (\i -> (i,1))
  . mapMaybe ((`elemIndex`"MARCH") . B.head)
  where
    f c = sum . map g $ filter(\b -> popCount b == 3) [7..2^5] where
      g :: Int->Int
      g b=product.map(c V.!)$filter(testBit b)[0..4]
