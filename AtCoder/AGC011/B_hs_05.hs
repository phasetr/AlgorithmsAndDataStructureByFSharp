-- https://atcoder.jp/contests/agc011/submissions/1158391
import Data.List ( sort )
import qualified Data.ByteString.Char8 as BC
import Data.Maybe (fromJust)

main :: IO()
main = do
  getLine
  as1 <- reverse . sort . map (fst . fromJust . BC.readInt) . BC.words <$> BC.getLine
  let _:asp = scanr1 (+) as1 ++ [0]
  print $ whileloop 1 as1 asp

whileloop :: Int->[Int]->[Int]->Int
whileloop n [] [] = n
whileloop n _ [] = n
whileloop n [] _= n
whileloop n (x:xs) (y:ys) = if x>y*2 then n else whileloop (n+1) xs ys
