-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_7_A/review/2904281/lvs7k/Haskell
{-# LANGUAGE BangPatterns #-}
import Control.Monad ( forM_ )
import qualified Data.ByteString.Char8 as B
import qualified Data.IntMap.Strict    as M
import           Data.Sequence         ((<|), (><), (|>))
import qualified Data.Sequence         as S
import           Data.Array.IArray ( Array, (!), array )
import           Data.Array.MArray ( freeze, writeArray, MArray(newArray) )
import           Data.Array.IO ( IOArray )

readi :: B.ByteString -> Int
readi bs | Just (n, _) <- B.readInt bs = n
readi _ = error "undefined"

calcDepth :: Int -> Array Int Int -> Int
calcDepth n pary = go 0 n where
  go !d !m
    | p == -1   = d
    | otherwise = go (d+1) p
    where p = pary ! m

printList :: [Int] -> IO ()
printList [] = putStr "[]"
printList (x:xs) = putStr ("[" ++ show x) >> go xs >> putStr "]" where
  go []     = return ()
  go (y:ys) = putStr (", " ++ show y) >> go ys

main :: IO ()
main = do
  n <- readLn :: IO Int
  let f (i:_:cs) = (i, cs)
      f _ = error "undefined"
  xss <- fmap (fmap (f . fmap readi . B.words) . B.lines) B.getContents

  paryM <- newArray (0, n-1) (-1) :: IO (IOArray Int Int)
  forM_ xss $ \(i, cs) -> do
    forM_ cs $ \c -> do
      writeArray paryM c i

  pary <- freeze paryM :: IO (Array Int Int)
  let cary = array (0, n-1) xss :: Array Int [Int]

  forM_ [0 .. n-1] $ \i -> do
    let parent = pary ! i
    let children = cary ! i
    putStr $ "node " ++ show i ++ ": "
    putStr $ "parent = " ++ show parent ++ ", "
    putStr $ "depth = " ++ show (calcDepth i pary) ++ ", "
    let ntype = case () of
                  _ | parent == -1  -> "root"
                    | null children -> "leaf"
                    | otherwise     -> "internal node"
    putStr $ ntype ++ ", "
    printList children
    putStrLn ""
