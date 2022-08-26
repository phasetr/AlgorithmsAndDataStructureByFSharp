-- https://onlinejudge.u-aizu.ac.jp/courses/lesson/1/ALDS1/all/ALDS1_5_B
import qualified Data.ByteString.Char8 as B
import Data.Maybe ( fromJust )
main :: IO()
main = do
  n <- fmap (fst . fromJust . B.readInt) B.getLine
  ss <- fmap (map (fst . fromJust . B.readInt) . B.words) B.getLine
  let (lst, cnt) = msort n ss
  putStrLn $ unwords $ map show lst
  print cnt

msort :: Int -> [Int] -> ([Int],Int)
msort 1 l = (l,0)
msort n l = merge (msort ln ll) (msort rn rl) where
  (ln,rn) = (div n 2, n - ln)
  (ll,rl) = splitAt ln l

merge :: ([Int],Int) -> ([Int],Int) -> ([Int],Int)
merge (ll,lc) (rl,rc) = help (lc+rc) [] ll rl where
  help c acc [] rl = (reverse acc ++ rl, c+length rl)
  help c acc ll [] = (reverse acc ++ ll, c+length ll)
  help c acc ll@(l:ls) rl@(r:rs)
    | l <= r    = c `seq` help (c+1) (l:acc) ls rl
    | otherwise = c `seq` help (c+1) (r:acc) ll rs

test :: IO ()
test = print $ msort 10 [8,5,9,2,6,3,7,1,10,4] -- == ([1,2,3,4,5,6,7,8,9,10],34)
