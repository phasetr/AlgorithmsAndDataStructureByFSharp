-- https://atcoder.jp/contests/abc111/submissions/13411015
import Data.Maybe (fromJust)
import qualified Data.ByteString.Char8 as BS
import Data.List (group,sort,sortOn)
import Data.Ord (Down(Down))

main :: IO ()
main = do
  n <- fst . fromJust . BS.readInt <$> BS.getLine
  (os,es) <- f . map (fst . fromJust . BS.readInt) . BS.words <$> BS.getLine
  print $ solve os es

f :: [a] -> ([a], [a])
f [] = ([],[])
f (a:b:xs) = let (as,bs) = f xs in (a:as, b:bs)
f _ = undefined

solve :: Ord b => [b] -> [b] -> Int
solve os es | snd o /= snd e = sumo + sume
            | null os' && null es' = fst o
            | otherwise = min (sum (map fst (o : tail os')) + sume) (sum (map fst (e : tail es')) + sumo)
  where
    (o:os') = fm os
    (e:es') = fm es
    sumo = sum $ map fst os'
    sume = sum $ map fst es'
    fm = sortOn Down . map (\g -> (length g, head g)) . group . sort
