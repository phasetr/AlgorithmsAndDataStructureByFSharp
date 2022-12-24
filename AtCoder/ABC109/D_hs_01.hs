{-# LANGUAGE ConstraintKinds #-}
-- https://atcoder.jp/contests/abc109/submissions/14908195
import Control.Monad ( replicateM )
import Data.Maybe ( fromJust )
import qualified Data.ByteString.Char8 as BS
import Data.List ( foldl' )

getIntList :: IO [Int]
getIntList = map (fst . fromJust . BS.readInt) . BS.words <$> BS.getLine

main :: IO ()
main = do
  [h,w] <- getIntList
  as <- concat . zipWith (\f a -> f a) (cycle [id, reverse]) . ind2D <$> replicateM h getIntList
  let ans = reverse . (\(a,_,_) -> a) $ foldl' count ([],True,(0,0)) as
  print $ length ans
  mapM_ putStrLn ans

ind2D :: [[b]] -> [[((Integer, Integer), b)]]
ind2D = zipWith (\i bs -> zipWith (\j b -> ((i,j),b)) [1..] bs) [1..]

count :: (Integral a1, Show a2, Show b1, Show a3, Show b2) => ([[Char]], Bool, (a2, b1)) -> ((a3, b2), a1) -> ([[Char]], Bool, (a3, b2))
count (s,e,(i,j)) ((k,l),b)
  | e && even b = (s,True,(k,l))
  | e && odd b = (s,False,(k,l))
  | even b = (p:s,False,(k,l))
  | otherwise = (p:s,True,(k,l))
  where p = show i ++ " " ++ show j ++ " " ++ show k ++ " " ++ show l

test = do
  let inputs = [[1,2,3],[0,1,1]]
  print $ ind2D inputs
  let as = concat . zipWith (\f a -> f a) (cycle [id, reverse]) $ ind2D inputs
  print as
  print $ foldl' count ([],True,(0,0)) as
