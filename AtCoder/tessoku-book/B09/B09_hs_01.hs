-- https://atcoder.jp/contests/tessoku-book/submissions/35223056
import Control.Monad ( replicateM )
import qualified Data.ByteString.Char8 as BS
import Data.Functor ( (<&>) )
import Data.Char ( isSpace )
import Data.List ( unfoldr )
import Data.Array.Unboxed ( accumArray, elems, UArray )

tbb09 :: Int -> [[Int]] -> Int
tbb09 n abcds = length $ filter (0 <) $ concat aas where
  da :: UArray (Int,Int) Int
  da = accumArray (+) 0 ((0,0),(1500,1500)) $
    [ p
    | (a:b:c:d:_) <- abcds
    , p@((x,y),_) <- [((a,b),1),((a,d),-1),((c,b),-1),((c,d),1)]
    ]
  axs = map (scanl1 (+)) $ chomp 1501 $ elems da
  aas = scanl1 (zipWith (+)) axs

chomp :: Int -> [a] -> [[a]]
chomp _ [] = []
chomp n xs = let (as,bs) = splitAt n xs in as : chomp n bs

main :: IO ()
main = do
  [n] <- bsGetLnInts
  abcds <- replicateM n bsGetLnInts
  let ans = tbb09 n abcds
  print ans

bsGetLnInts :: IO [Int]
bsGetLnInts = BS.getLine <&> unfoldr (BS.readInt . BS.dropWhile isSpace)
