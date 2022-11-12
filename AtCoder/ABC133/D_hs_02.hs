-- https://atcoder.jp/contests/abc133/submissions/19536989
import qualified Data.ByteString.Char8 as B
import qualified Data.Vector.Unboxed as V
main :: IO ()
main = putStrLn . unwords . map show . solve =<<
  (\n -> V.unfoldrN n (B.readInt . B.dropWhile(==' ')) <$> B.getLine) =<< readLn
solve :: V.Vector Int -> [Int]
solve = V.toList . V.init . (V.scanl' (\b a -> a*2-b) =<< V.foldr1' (-))
