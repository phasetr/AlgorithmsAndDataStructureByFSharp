-- https://atcoder.jp/contests/abc080/submissions/16745538
import Control.Arrow ( Arrow(first) )
import Data.Bits ( Bits((.&.), popCount) )
import Data.Char ( isSpace )
import qualified Data.ByteString.Char8 as B
import qualified Data.Vector as V
main :: IO ()
main = print . solve . map (V.unfoldr $ B.readInt . B.dropWhile isSpace) . B.lines =<< B.getContents

solve :: [V.Vector Int] -> Int
solve (n:fp) = maximum $ map g [1..1023] where
  fps = uncurry zip . first (map (V.foldl' (\v f -> v*2 + f) 0)) $ splitAt (n V.! 0) fp
  g b = sum $ map (\(f,p) -> p V.! popCount (f.&.b)) fps
solve _ = error "not come here"
