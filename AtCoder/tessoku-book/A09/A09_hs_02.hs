-- https://atcoder.jp/contests/tessoku-book/submissions/35216175
import Control.Monad ( forM, replicateM )
import qualified Data.ByteString.Char8 as BS
import Data.Char ( isSpace )
import Data.Functor ( (<&>) )
import Data.List ( intersperse, unfoldr )
import Data.Array.Unboxed ( accumArray, elems, UArray )

tba09 :: Int -> Int -> Int -> [[Int]] -> [[Int]]
tba09 h w n abcds = aas where
  da :: UArray (Int,Int) Int
  da = accumArray (+) 0 ((1,1),(h,w)) $
    [ p
    | (a:b:c:d:_) <- abcds
    , p@((x,y),_) <- [((a,b),1),((a,succ d),-1),((succ c,b),-1),((succ c, succ d),1)]
    , x <= h, y <= w
    ]
  axs = map (scanl1 (+)) $ chomp w $ elems da
  aas = scanl1 (zipWith (+)) axs

chomp :: Int -> [a] -> [[a]]
chomp _ [] = []
chomp n xs = let (as,bs) = splitAt n xs in as : chomp n bs

main :: IO [()]
main = do
  [h,w,n] <- bsGetLnInts
  abcds <- replicateM n bsGetLnInts
  let ans = tba09 h w n abcds
  forM ans (putStrLn . foldr ($) "" . intersperse (' ' :) . map shows)

bsGetLnInts :: IO [Int]
bsGetLnInts = BS.getLine <&> unfoldr (BS.readInt . BS.dropWhile isSpace)
