-- https://onlinejudge.u-aizu.ac.jp/problems/ALDS1_5_A
import Control.Monad ( filterM )
main :: IO ()
main = do
  getLine
  as <- fmap (map read . words) getLine
  getLine
  ms <- fmap (map read . words) getLine
  mapM_ putStrLn (solve as ms)
solve :: [Int] -> [Int] -> [String]
solve as = map ((\b -> if b then "yes" else "no") . (`elem` sums))
  where sums = map sum . filterM (const [True,False]) $ as

test :: IO ()
test = print $ solve [1,5,7,10,21] [2,4,17,8] == ["no","no","yes","yes"]
