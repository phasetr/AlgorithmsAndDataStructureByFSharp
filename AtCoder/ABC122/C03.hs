-- https://atcoder.jp/contests/abc122/submissions/12910470
import Control.Monad (replicateM_)
import Data.Maybe (fromJust)
import qualified Data.ByteString.Char8 as BS
import qualified Data.Vector as V

readInt = fst . fromJust . BS.readInt
readIntList = map readInt . BS.words
getInt = readInt <$> BS.getLine
getIntList = readIntList <$> BS.getLine

main = do
  [n, q] <- getIntList
  s <- getLine
  let acs = V.fromList $ scanl (+) 0 (cl s)
  replicateM_ q $ do
    [l,r] <- getIntList
    print $ (acs V.! r) - (acs V.! l)

cl :: Num a => String -> [a]
cl [] = []
cl [c] = 0 : cl []
cl (a:b:cs) | [a,b] == "AC" = 0 : 1 : cl cs
            | otherwise = 0 : cl (b:cs)
