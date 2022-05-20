-- https://onlinejudge.u-aizu.ac.jp/courses/lesson/2/ITP1/all/ITP1_7_C
import Control.Applicative ((<$>))
import Text.Printf (printf)
main :: IO ()
main = do
  [r,c] <- map read . words <$> getLine
  xss <- map (map read . words) . lines <$> getContents
  mapM_ putStrLn (solve r c xss)

solve :: Int -> Int -> [[Int]] -> [String]
solve r c = reverse
  . (\(acc,ss) -> printf "%s %d" (unwords $ map show acc) (sum acc) : ss)
  . foldl (\(acc,ss) xs -> (zipWith (+) acc xs, f xs:ss))
  (replicate c 0, [])
f :: [Int] -> String
f xs = printf "%s %d" (unwords $ map show xs) (sum xs)

--solve 4 5 [[1,1,3,4,5],[2,2,2,4,5],[3,3,0,1,1],[2,3,4,4,6]]
