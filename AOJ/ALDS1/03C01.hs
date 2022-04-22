{-
https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_3_C/review/2890701/lvs7k/Haskell

For Data.Sequence
https://hackage.haskell.org/package/containers-0.6.5.1/docs/Data-Sequence.html
The implementation uses 2-3 finger trees
-}
{-# LANGUAGE BangPatterns      #-}
{-# LANGUAGE OverloadedStrings #-}

import qualified Data.ByteString.Char8 as B
import           Data.Foldable (toList)
import qualified Data.Sequence         as S

insert :: a -> S.Seq a -> S.Seq a
insert = (S.<|)

delete :: Eq a => a -> S.Seq a -> S.Seq a
delete x s =
  case S.viewl r of
    S.EmptyL -> s
    x S.:< xs -> l S.>< xs
  where (l,r) = S.breakl (== x) s

deleteFirst :: S.Seq a -> S.Seq a
deleteFirst s =
  case S.viewl s of
    S.EmptyL -> s
    x S.:< xs -> xs

deleteLast :: S.Seq a -> S.Seq a
deleteLast s =
  case S.viewr s of
    S.EmptyR -> s
    xs S.:> x -> xs

solve :: [(B.ByteString, Int)] -> String
solve = unwords . map show . toList . procLine S.empty where
  procLine !seq [] = seq
  procLine !seq ((com,n):cs)
    | com == "insert"      = procLine (insert n seq) cs
    | com == "delete"      = procLine (delete n seq) cs
    | com == "deleteFirst" = procLine (deleteFirst seq) cs
    | com == "deleteLast"  = procLine (deleteLast seq) cs
  procLine _ _ = undefined

main :: IO ()
main = B.getLine >> B.getContents >>=
  putStrLn . solve . map (f . B.words) . B.lines

f :: [B.ByteString] -> (B.ByteString, Int)
f [a] = (a,0)
f [a,b] = (a,n) where Just (n,_) = B.readInt b
f _ = undefined

test :: IO ()
test = do
  print $ solve [(B.pack "insert",5),(B.pack "insert",2),(B.pack "insert",3),(B.pack "insert",1),(B.pack "delete",3),(B.pack "insert",6),(B.pack "delete",5)]
    == "6 1 2"
  print $ solve [(B.pack "insert",2),(B.pack "insert",3),(B.pack "insert",1),(B.pack "delete",3),(B.pack "insert",6),(B.pack "delete",5),(B.pack "deleteFirst",0),(B.pack "deleteLast",0)]
    == "1"
