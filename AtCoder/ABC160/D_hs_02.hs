-- https://atcoder.jp/contests/abc160/submissions/11302646
{-# LANGUAGE TupleSections #-}
import qualified Data.Text as T
import qualified Data.Text.IO as T
import qualified Data.Text.Read as T
import qualified Data.Vector.Unboxed as VU
import GHC.LanguageExtensions (Extension(TupleSections))

main :: IO ()
main = do
  (n : x : y : _) <- map unsafeTextToInt . T.words <$> T.getLine :: IO [Int]
  let
    d :: Int -> Int -> Int
    d i j | j <= x || y <= i = j - i
          | otherwise        = min (j - i) (abs (j - y) + 1 + abs (x - i))
    ds = [1..(pred n)] >>= \i -> [(succ i)..n] >>= \j -> return (d i j) :: [Int]
  VU.mapM_ print . VU.tail . count n $ ds

count :: Int -> [Int] -> VU.Vector Int
count n = VU.accum (+) (VU.replicate n 0) . map (1,)

unsafeTextToInt :: T.Text -> Int
unsafeTextToInt s = case T.signed T.decimal s of
  Right (n, _) -> n
  _ -> error "not come here"
