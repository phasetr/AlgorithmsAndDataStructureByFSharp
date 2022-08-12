-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_2_D/review/2211143/matonix/Haskell
{-# OPTIONS_GHC -O2 -funbox-strict-fields #-}
{-# OPTIONS_GHC -fno-warn-unused-imports #-}
{-# OPTIONS_GHC -fno-warn-missing-signatures #-}
{-# OPTIONS_GHC -fno-warn-unused-binds #-}
{-# OPTIONS_GHC -fno-warn-incomplete-patterns #-}
{-# OPTIONS_GHC -fno-warn-name-shadowing #-}
{-# LANGUAGE OverloadedStrings #-}
{-# LANGUAGE FlexibleContexts #-}

import           System.IO hiding (char8)
import Control.Monad ( when, forM_, replicateM )
import Data.List ( intersperse )
import           Data.Function (on)
import           Data.Ord (comparing)
import           Data.Monoid (mappend)
import Data.Array.ST ( getElems, newListArray, MArray(getBounds) )
import Data.Maybe ( fromJust )
import qualified Data.ByteString.Char8 as BS
import qualified Data.ByteString.Lazy.Char8 as BL
import Data.ByteString.Builder ( toLazyByteString, char8, intDec )
import Data.Array.Base(unsafeRead, unsafeWrite)
import Data.Array.IO
    ( getElems, newListArray, MArray(getBounds), IOUArray )

main :: IO ()
main = do
  n <- fmap readInt1 BS.getLine
  ns <- fmap (map readInt1) (replicateM n BS.getLine)
  arr <- newListArray (0, n) (0:ns) :: IO (IOUArray Int Int)
  let intervals = reverse . takeWhile (<= n) $ iterate (\x -> 3 * x + 1) 1
  print $ length intervals
  putIntN intervals
  shellSort arr intervals
  es <- getElems arr
  mapM_ print es

-- use array[0] for store "cnt"

shellSort :: (MArray a Int m) => a Int Int -> [Int] -> m ()
shellSort arr intervals = forM_ intervals $ \interval ->
  forM_ [1..interval] $ insertionSort arr interval

insertionSort :: (MArray a Int m) => a Int Int -> Int -> Int -> m ()
insertionSort arr interval offset = do
  (_,n) <- getBounds arr
  let startlines = takeWhile (<=n) $ map ((+offset).(*interval)) [0..]
  forM_ startlines $ insertion arr interval
  t <- unsafeRead arr interval
  unsafeWrite arr interval t

insertion :: (MArray a Int m) => a Int Int -> Int -> Int -> m ()
insertion arr interval r = do
  let l = r - interval
  when (l > 0) $ do
    x <- unsafeRead arr l
    y <- unsafeRead arr r
    when (x > y) $ do
      increment arr
      swapArray arr l r
      insertion arr interval l

swapArray :: (MArray a Int m) => a Int Int -> Int -> Int -> m ()
swapArray arr i j = do
  x <- unsafeRead arr i
  y <- unsafeRead arr j
  unsafeWrite arr i y
  unsafeWrite arr j x

increment :: (MArray a Int m) => a Int Int -> m ()
increment arr = do
  x <- unsafeRead arr 0
  unsafeWrite arr 0 $ x+1

-- [1,2,3] -> 1 2 3
putIntN :: [Int] -> IO ()
putIntN [] = return ()
putIntN xs = BL.putStrLn . toLazyByteString . foldl1 mappend . intersperse (char8 ' ') $ map intDec xs

readInt1 :: BS.ByteString -> Int
readInt1 = fst . fromJust . BS.readInt
