-- https://atcoder.jp/contests/tessoku-book/submissions/38085684
import Data.Bits ( Bits(xor) )
import Data.Bool ( bool )
import Data.List ( foldl1' )
import Data.Vector.Generic ((!))
import qualified Data.Vector.Unboxed as U

main :: IO ()
main = (getLine *> get) >>= putStrLn . bool "Second" "First" . sol

get :: IO [Int]
get = map read . words <$> getLine

sol :: [Int] -> Bool
sol = (>0) . foldl1' xor . map ((grundy!) . (`mod` 5)) where
  grundy = U.fromListN 5 [0 :: Int,0,1,1,2]
