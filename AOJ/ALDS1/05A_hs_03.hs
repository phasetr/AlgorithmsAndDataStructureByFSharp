-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_5_A/review/1929486/tiqwab_ch90/Haskell
import Control.Monad ( filterM )
main :: IO ()
main = do
  getLine
  numbers <- fmap (map read . words) getLine
  let possibleAdditions = map addAll . filterM (const [True, False]) $ numbers
  getLine
  targets <- fmap (map read . words) getLine
  mapM_ (putStrLn . yesno . (`elem` possibleAdditions)) targets

addAll :: [Int] -> Int
addAll [] = 0
addAll xs = sum xs

yesno :: Bool -> String
yesno True  = "yes"
yesno False = "no"
