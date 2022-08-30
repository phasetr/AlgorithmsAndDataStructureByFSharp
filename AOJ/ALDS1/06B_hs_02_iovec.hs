-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_6_B/review/4642784/niruneru/Haskell
{-# LANGUAGE BangPatterns #-}

import Control.Applicative ((<$>))
import Data.Maybe (fromJust)
import Data.Vector.Unboxed (Vector, (!), unsafeFreeze, unsafeThaw, fromList, toList)
import Data.Vector.Unboxed.Mutable (IOVector, unsafeRead, unsafeSwap)
import qualified Data.Vector.Unboxed as V
import qualified Data.Vector.Unboxed.Mutable as MV
import qualified Data.ByteString.Char8 as BS

main :: IO ()
main = getLine
  >>  fromList . map (fst . fromJust . BS.readInt) . BS.words <$> BS.getLine
  >>= unsafeThaw
  >>= partition
  >>= forAnswer
  >>= putStrLn

partition :: IOVector Int -> IO (Int, Vector Int)
partition !inputs = do
  pivot   <- unsafeRead inputs (MV.length inputs - 1)
  pos     <- checkAndSwap inputs pivot (-1) 0 (MV.length inputs - 1)
  inputs' <- unsafeFreeze inputs
  return (pos, inputs')

checkAndSwap :: IOVector Int -> Int -> Int -> Int -> Int -> IO Int
checkAndSwap !inputs !pivot !i !j !end
    | j == end  = do
        unsafeSwap inputs (i + 1) end
        return (i + 1)
    | otherwise = do
        v <- unsafeRead inputs j
        if v <= pivot then
             do unsafeSwap inputs (i + 1) j
                checkAndSwap inputs pivot (i + 1) (j + 1) end
        else do checkAndSwap inputs pivot i (j + 1) end

forAnswer :: (Int, Vector Int) -> IO String
forAnswer (i, xs) = return $ before ++ mid ++ after where
  before = unwords . map show . toList $ V.take i xs
  after  = unwords . map show . toList $ V.drop (i + 1) xs
  mid    = " [" ++ show (xs ! i) ++ "] "
