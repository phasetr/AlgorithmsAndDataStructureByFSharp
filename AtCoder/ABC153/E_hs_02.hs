-- https://atcoder.jp/contests/abc153/submissions/9786461
import Control.Monad ( replicateM )
import qualified Data.Text as T
import qualified Data.Text.IO as T
import qualified Data.Text.Read as T
import qualified Data.Vector.Unboxed as VU

main :: IO ()
main = do
  (h : n : _) <- map unsafeTextToInt . T.words <$> T.getLine
  abs <- replicateM n $ unsafeListToTuple . map unsafeTextToInt . T.words <$> T.getLine
  let
    abs' = VU.fromList abs
    minSumBs :: VU.Vector Int
    minSumBs = VU.constructN (succ h) rec where
      rec v | l == 0    = 0
            | otherwise = VU.minimum . VU.map ((+) <$> (v VU.!) . max 0 . flip subtract l . fst <*> snd) $ abs'
        where l = VU.length v
  print $ minSumBs VU.! h

unsafeListToTuple :: [Int] -> (Int, Int)
unsafeListToTuple (x : y : _) = (x, y)
unsafeListToTuple _ = error "not come here"

unsafeTextToInt :: T.Text -> Int
unsafeTextToInt s = case T.signed T.decimal s of
  Right (n, _) -> n
  _ -> error "not come here"
