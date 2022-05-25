-- https://onlinejudge.u-aizu.ac.jp/courses/lesson/1/ALDS1/all/ALDS1_6_A
-- AOJでは通らない: sortOnがないバージョンを使っている?
import Data.Maybe ( fromJust )
import qualified Data.ByteString.Char8 as B
import qualified Data.IntMap as IM
import qualified Data.List as L

main :: IO ()
main = getLine >> B.getLine >>=
  putStrLn . unwords . map show
  . csort . map (fst . fromJust . B.readInt) . B.words

csort :: [IM.Key] -> [IM.Key]
csort as = concatMap (\(i,v) -> replicate v i) (L.sortOn fst pairs)
  where pairs = IM.toList $ generateIM as
generateIM :: [IM.Key] -> IM.IntMap Int
generateIM = foldr (flip (IM.insertWith (+)) 1) IM.empty

test :: IO ()
test = do
  let as = [2,5,1,3,2,3,0]
  print $ generateIM as == IM.fromList [(0,1),(1,1),(2,2),(3,2),(5,1)]
  print $ concatMap (\(i,v) -> replicate v i) (L.sortOn fst (IM.toList (generateIM as)))
  print $ csort [2,5,1,3,2,3,0] == [0,1,2,2,3,3,5]
