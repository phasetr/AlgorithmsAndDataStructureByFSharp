-- https://atcoder.jp/contests/dp/submissions/14035370
import Data.Maybe ( fromJust )
import qualified Data.ByteString.Char8 as BS
import qualified Data.Array as A
import qualified Data.Vector.Unboxed as VU

main :: IO ()
main = do
  n <- fst . fromJust . BS.readInt <$> BS.getLine
  as <- VU.fromList . map (fst . fromJust . BS.readInt) . BS.words <$> BS.getLine
  let ss = VU.scanl (+) 0 as
  let arr = A.array ((1,1),(n,n)) [((l,r), f l r) | l <- [1..n], r <- [1..n]] where
        f l r | l >= r = 0
              | otherwise = minimum $ map g [l..r-1]
          where g m = (arr A.! (l,m)) + (arr A.! (m+1,r)) + (ss VU.! r) - (ss VU.! (l-1))
  print $ arr A.! (1,n)
