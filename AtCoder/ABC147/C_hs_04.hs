-- https://atcoder.jp/contests/abc147/submissions/11229331
import Control.Monad ( replicateM )
import Data.Maybe ( fromJust )
import qualified Data.ByteString.Char8 as BS

readInt = fst . fromJust . BS.readInt
readIntList = map readInt . BS.words
getInt = readInt <$> BS.getLine
getIntList = readIntList <$> BS.getLine

main :: IO ()
main = do
  n <- getInt
  xyss <- replicateM n $ do
    a <- getInt
    map (\(x:y:_) -> (x,y)) <$> replicateM a getIntList
  let bss = replicateM n [False, True]
  print . maximum $  [ (length . filter id) bs | bs <- bss, all (check bs) (zip bs xyss) ]

check :: (Foldable t, Eq a, Num a) => [Bool] -> (Bool, t (Int, a)) -> Bool
check bs (b, xys)
  | b = all (\(x, y) -> bs !! (x - 1) == (y == 1)) xys
  | otherwise = True
