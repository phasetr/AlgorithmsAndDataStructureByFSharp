-- https://atcoder.jp/contests/nikkei2019-qual/submissions/14506733
import Control.Monad ( replicateM )
import Data.Maybe ( fromJust )
import qualified Data.ByteString.Char8 as BS
import Data.List ( sortOn )
import Data.Ord ( Down(Down) )

main :: IO ()
main = do
  n <- fst . fromJust . BS.readInt <$> BS.getLine
  ds <- replicateM n $ do
    [a,b] <- map (fst . fromJust . BS.readInt) . BS.words <$> BS.getLine
    return (a+b, b)
  let ans = sum $ zipWith (\k (x,y) -> k*x-y) (cycle [1,0]) $ sortOn Down ds
  print ans
