-- https://atcoder.jp/contests/abc075/submissions/16926200
import Control.Monad ( replicateM )
import qualified Data.ByteString.Char8 as C
import Data.Graph ( buildG, dff, Vertex )
import Data.List ( (\\), unfoldr )

main :: IO ()
main = sub =<< get

sub :: [Int] -> IO ()
sub [n,m] = replicateM m get >>= print . sol n m
sub _ = error "not come here"

get :: IO [Int]
get = unfoldr (C.readInt . C.dropWhile (<'0')) <$> C.getLine

sol :: Int -> Int -> [[Vertex]] -> Int
sol n m es = length $ filter brdg ess where
  ess = map (\i -> es\\[es!!i]) [0..m-1]
  brdg = (>1) . length . dff . buildG (1,n) . concatMap (\[u,v] -> [(u,v),(v,u)])
