-- https://atcoder.jp/contests/dp/submissions/26335968
import qualified Data.ByteString.Char8 as BS
import Data.Char ( isSpace )
import Data.List ( foldl', unfoldr )

import qualified Data.IntMap as IM
import Data.Maybe ( fromJust )

main :: IO ()
main = do
  li <- BS.getLine
  let [n,w] = unfoldr (BS.readInt . BS.dropWhile isSpace) li
  co <- BS.getContents
  let wvs = map (unfoldr (BS.readInt . BS.dropWhile isSpace)) $ BS.lines co
  print $ solve n w wvs

solve :: Int -> Int -> [[Int]] -> Int
solve n wlim wvs = access valsn 0 where
  vals0 = IM.singleton wlim 0
  valsn = foldl' step vals0 wvs
  step vals [w,v] = IM.union vals1 vals2 where
    vals1 = IM.fromList $ (wlim,0) :
      [ (wa1, va1)
      | (wa,va) <- IM.assocs vals
      , wa >= w, let wa1 = wa - w
      , let va1 = va + v
      , access vals wa1 < va1]
    vals2 = IM.fromList
      [ (wa,va)
      | (wa,va) <- IM.assocs vals
      , access vals1 wa < va]
  step _ _ = undefined

access :: IM.IntMap b -> IM.Key -> b
access m k = snd $ fromJust $ IM.lookupGE k m
