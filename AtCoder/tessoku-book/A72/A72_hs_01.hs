-- https://atcoder.jp/contests/tessoku-book/submissions/35688463
import Control.Monad ( replicateM )
import Data.Maybe ( fromJust )
import qualified Data.ByteString.Char8 as BS
import Data.List ( sortOn, transpose )
import Data.Ord ( Down(Down) )
import qualified Data.Vector.Unboxed as VU
import qualified Data.Vector.Unboxed.Mutable as VUM
import qualified Data.IntSet as IS

readInt = fst . fromJust . BS.readInt
readIntList = map readInt . BS.words
getInt = readInt <$> BS.getLine
getIntList = readIntList <$> BS.getLine

main :: IO ()
main = do
  [h, w, k] <- getIntList
  sets <- map (f 0) .transpose <$> replicateM h getLine
  let minWhite = minimum [count sets (k-i, s) | i <- [0..k], s <- comb i [0..h-1]]
  print $ h * w - minWhite

f :: Int -> [Char] -> IS.IntSet
f _ [] = IS.empty
f i ('#' : xs) = f (i+1) xs
f i ('.' : xs) = IS.insert i $ f (i+1) xs
f _ _ = error "not come here"

comb :: (Eq t, Num t) => t -> [IS.Key] -> [IS.IntSet]
comb 0 xs = [IS.empty]
comb _ [] = []
comb n (x:xs) = [IS.insert x y | y <- comb (n-1) xs] ++ comb n xs

count :: [IS.IntSet] -> (Int, IS.IntSet) -> Int
count sets (m, s) = sum . drop m . sortOn Down $ map (\x -> IS.size (IS.difference x s)) sets
