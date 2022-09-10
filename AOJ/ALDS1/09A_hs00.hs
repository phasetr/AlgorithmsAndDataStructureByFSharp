-- https://onlinejudge.u-aizu.ac.jp/problems/ALDS1_9_A
import Control.Monad ( when )
import Data.Char ( isSpace )
import Data.Maybe ( fromJust, isJust )
import qualified Data.ByteString.Char8 as B
import qualified Data.Vector as V

main :: IO ()
main = do
  n  <- readLn
  xv <- fmap (V.unfoldr (B.readInt . B.dropWhile isSpace)) B.getLine
  V.forM_ (solve n xv) $ \(node, key, pkey, lkey, rkey) -> do
    putStr $ "node " ++ show node ++ ": "
    putStr $ "key = " ++ show key ++ ", "
    when (isJust pkey) $ do putStr $ "parent key = " ++ show (fromJust pkey) ++ ", "
    when (isJust lkey) $ do putStr $ "left key = " ++ show (fromJust lkey) ++ ", "
    when (isJust rkey) $ do putStr $ "right key = " ++ show (fromJust rkey) ++ ", "
    putStrLn ""

solve :: Int -> V.Vector Int -> V.Vector (Int, Int, Maybe Int, Maybe Int, Maybe Int)
solve n xv =
  V.imap (\i x -> (i+1, x, pkey i, lkey i, rkey i)) xv
  where
    pkey i = if i==0 then Nothing else Just (xv V.! ((i-1) `div` 2))
    lkey i = let j=i*2+1 in if j<n then Just (xv V.! j) else Nothing
    rkey i = let j=i*2+2 in if j<n then Just (xv V.! j) else Nothing

test :: IO ()
test = do
  print $ solve 5 (V.fromList [7,8,1,2,3])
    == V.fromList
    [(1,7,Nothing,Just 8, Just 1),
     (2,8,Just 7,Just 2, Just 3),
     (3,1,Just 7,Nothing,Nothing),
     (4,2,Just 8,Nothing,Nothing),
     (5,3,Just 8,Nothing,Nothing)]
  print $ solve 6 (V.fromList [10,8,5,1,2,3])
    == V.fromList
    [(1,10,Nothing,Just 8,Just 5),
     (2,8,Just 10,Just 1,Just 2),
     (3,5,Just 10,Just 3,Nothing),
     (4,1,Just 8,Nothing,Nothing),
     (5,2,Just 8,Nothing,Nothing),
     (6,3,Just 5,Nothing,Nothing)]
