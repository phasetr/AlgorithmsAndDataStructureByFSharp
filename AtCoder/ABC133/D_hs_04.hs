-- https://atcoder.jp/contests/abc133/submissions/14402763
import Data.Maybe ( fromJust )
import qualified Data.ByteString.Char8 as BS
import Data.List ( scanl' )

readInt = fst . fromJust . BS.readInt
readIntList = map readInt . BS.words
getInt = readInt <$> BS.getLine
getIntList = readIntList <$> BS.getLine

main :: IO ()
main = do
  getLine
  as <- getIntList
  let x1 = (`div` 2) . sum $ zipWith (*) (cycle [1, -1]) as
  let ans = map (2*) $ scanl' (flip (-)) x1 (init as)
  putStrLn . unwords $ map show ans
