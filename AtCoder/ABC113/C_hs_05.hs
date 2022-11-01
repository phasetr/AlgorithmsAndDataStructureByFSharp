-- https://atcoder.jp/contests/abc113/submissions/35025803
import Control.Monad ( replicateM )
import qualified Data.ByteString.Char8 as BS
import Data.Char ( isSpace )
import Data.Functor ( (<&>) )
import Data.List ( sort, unfoldr )
import Data.Array ( Array, elems, array, accumArray, assocs )

main :: IO ()
main = do
  [n,m] <- bsGetLnInts
  pys <- replicateM m bsGetLnInts
  let ans = abc113c n m pys
  mapM_ putStrLn ans

bsGetLnInts :: IO [Int]
bsGetLnInts = BS.getLine <&> unfoldr (BS.readInt . BS.dropWhile isSpace)

abc113c :: Int -> Int -> [[Int]] -> [String]
abc113c n m pys = elems a2
  where
    a1 :: Array Int [(Int,Int)]
    a1 = accumArray (flip (:)) [] (1,n) [(p,(y,i)) | (i,p:y:_) <- zip [1..] pys]
    a2 :: Array Int String
    a2 = array (1,m) [(i, six p ++ six j) | (p,yis) <- assocs a1, (j,(y,i)) <- zip [1..] $ sort yis]

six :: Int -> [Char]
six = tail . show . (1000000 +)
