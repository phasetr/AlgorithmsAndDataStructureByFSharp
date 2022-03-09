{-
https://atcoder.jp/contests/abc131/submissions/6153980
-}
import Data.List (sortOn)
import qualified Data.ByteString.Char8 as BC
import Data.Maybe (fromJust)

solve :: [(Int, Int)] -> String
solve = frec 0 . sortOn snd where
  frec :: (Ord t, Num t) => t -> [(t, t)] -> String
  frec _ [] = "Yes"
  frec acc ((a,b):xs)
    | acc+a<=b  = frec (acc+a) xs
    | otherwise = "No"

main :: IO()
main = BC.getContents
  >>= putStrLn . solve . map ((\[x,y] -> (x,y)) . map (fst . fromJust . BC.readInt) . BC.words) . tail . BC.lines

test :: IO ()
test = do
  print $ solve [(2,4),(1,9),(1,8),(4,9),(3,12)] == "Yes"
  print $ solve [(334,1000),(334,1000),(334,1000)] == "No"
  print $ solve [(384,8895),(1725,9791),(170,1024),(4,11105),(2,6),(578,1815),(702,3352),(143,5141),(1420,6980),(24,1602),(849,999),(76,7586),(85,5570),(444,4991),(719,11090),(470,10708),(1137,4547),(455,9003),(110,9901),(15,8578),(368,3692),(104,1286),(3,4),(366,12143),(7,6649),(610,2374),(152,7324),(4,7042),(292,11386),(334,5720)] == "Yes"
