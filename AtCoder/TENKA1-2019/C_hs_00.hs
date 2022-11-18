-- https://atcoder.jp/contests/tenka1-2019/submissions/5047235
import qualified Data.ByteString.Char8 as BS
import qualified Data.Vector.Unboxed as U

main :: IO ()
main = do
  n <- readLn
  cv <- U.unfoldrN n BS.uncons <$> BS.getLine
  print $ solve cv
solve :: U.Vector Char -> Int
solve cv = U.minimum $ U.zipWith (+) b w where
  b = U.scanl (\acc c -> if c=='#' then acc+1 else acc) 0 cv
  w = U.scanr (\c acc -> if c=='.' then acc+1 else acc) 0 cv

test = do
  let cv = U.fromList "#.#"
  print cv
  print (U.scanl (+) 0 $ U.map (\c -> if c=='#' then 1 else 0) cv :: U.Vector Int)
  print (U.scanl (\acc c -> if c=='#' then acc+1 else acc) 0 cv :: U.Vector Int)
  print (U.scanr (\c acc -> if c=='.' then acc+1 else acc) 0 cv :: U.Vector Int)
  print $ scanr max 18 [3,6,12,4,55,11]
