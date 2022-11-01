-- https://atcoder.jp/contests/abc113/submissions/31813094
import Control.Monad ( forM_, replicateM )
import Data.List ( groupBy, sort, sortBy )
import Text.Printf ( printf )

main :: IO ()
main = do
  [n,m] <- map read . words <$> getLine
  py <- replicateM m $ do
    [p,y] <- map read . words <$> getLine :: IO [Int]
    return (p,y)
  let py' = zip py [1..] :: [((Int,Int),Int)]
  let py'' = groupBy (\x y -> fst (fst x) == fst (fst y)) $ sort py'
  let py''' = concatMap (zip [1..]) py'' :: [(Int,((Int,Int),Int))]
  let py'''' = sortBy (\x y -> compare (snd (snd x)) (snd (snd y))) py'''
  let py''''' = map (\(x,((y,_),_)) -> (y,x)) py''''
  forM_ py''''' $ \(x,y) -> do
    printf "%06d%06d\n" x y
