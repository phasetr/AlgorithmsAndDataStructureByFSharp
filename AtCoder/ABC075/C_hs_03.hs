-- https://atcoder.jp/contests/abc075/submissions/14404569
import Control.Monad ( replicateM )
import Data.Maybe ( fromJust )
import qualified Data.ByteString.Char8 as BS
import Data.List ( delete )
import qualified Data.Graph as G

readInt = fst . fromJust . BS.readInt
readIntList = map readInt . BS.words
getInt = readInt <$> BS.getLine
getIntList = readIntList <$> BS.getLine

main :: IO ()
main = do
  [n,m] <- getIntList
  edge <- replicateM m $ do
    [a,b] <- getIntList
    return (a,b)
  let es edge = edge ++ map (\(a,b) -> (b,a)) edge
  let ans = length [()| e <- edge, (> 1) . length . G.components $ G.buildG (1,n) (es (delete e edge))]
  print ans
