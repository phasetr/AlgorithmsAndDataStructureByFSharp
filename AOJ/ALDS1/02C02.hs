-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_3_C/review/2890701/lvs7k/Haskell
{-# LANGUAGE BangPatterns      #-}
{-# LANGUAGE OverloadedStrings #-}

import           Control.Applicative
import           Control.Monad
import qualified Data.ByteString.Char8 as B
import           Debug.Trace

import           Data.Sequence         (Seq (..), ViewL (..), ViewR (..), (<|),
                                        (><), (|>))
import qualified Data.Sequence         as S

readInt' :: B.ByteString -> Int
readInt' bs | Just (n, _) <- B.readInt bs = n

insert :: a -> Seq a -> Seq a
insert = (<|)

delete :: Eq a => a -> Seq a -> Seq a
delete x s =
    case S.viewl r of
        EmptyL -> s
        x :< xs -> l >< xs
  where
    (l, r) = S.breakl (== x) s

deleteFirst :: Seq a -> Seq a
deleteFirst s =
    case S.viewl s of
        x :< xs -> xs

deleteLast :: Seq a -> Seq a
deleteLast s =
    case S.viewr s of
        xs :> x -> xs

make :: [(B.ByteString, Int)] -> Seq Int
make xs = go S.empty xs
  where
    go !seq [] = seq
    go !seq ((com,n):cs)
        | com == "insert" = go (insert n seq) cs
        | com == "delete" = go (delete n seq) cs
        | com == "deleteFirst" = go (deleteFirst seq) cs
        | com == "deleteLast"  = go (deleteLast seq) cs

print' :: Seq Int -> IO ()
print' s =
    case S.viewl s of
        EmptyL -> putStrLn ""
        a :< s' -> putStr (show a) >> go s'
  where
    go s =
        case S.viewl s of
            EmptyL -> putStrLn ""
            a :< s' -> putStr (" " ++ show a) >> go s'

main :: IO ()
main = do
    B.getLine
    let f xs =
            case xs of
                [a]    -> (a, 0)
                [a, b] -> (a, readInt' b)
    xs <- fmap (f . B.words) . B.lines <$> B.getContents
    print' $ make xs


