{-
https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_3_C/review/2890701/lvs7k/Haskell
See also ../AOJ/ALDS1/02C01.hs

For Data.Sequence
https://hackage.haskell.org/package/containers-0.6.5.1/docs/Data-Sequence.html
The implementation uses 2-3 finger trees
-}
import qualified Data.Sequence as S

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
