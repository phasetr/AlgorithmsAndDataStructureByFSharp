-- https://atcoder.jp/contests/keyence2019/submissions/12932726
import Data.Maybe (fromJust)
import qualified Data.ByteString.Char8 as BS
import Data.List (sortOn)
import Data.Ord (Down(Down))

main = do
  getLine
  as <- map (fst . fromJust . BS.readInt) . BS.words <$> BS.getLine
  bs <- map (fst . fromJust . BS.readInt) . BS.words <$> BS.getLine
  let ds = sortOn Down $ zipWith (-) as bs
      mds = filter (< 0) ds
      m = length mds
      p = length . takeWhile (< abs (sum mds)) $ scanl (+) 0 ds
  print $ if sum ds < 0 then -1 else m + p
