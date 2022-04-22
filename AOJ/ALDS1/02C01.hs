-- https://onlinejudge.u-aizu.ac.jp/problems/ALDS1_2_C
import Data.List ( unfoldr, minimumBy )
import Data.Ord ( comparing )

bsort :: [String] -> [String]
bsort = unfoldr bubble where
  bubble = foldr step Nothing where
    xs `step` Nothing = Just (xs,[])
    xs `step` Just (ys,yss)
      | comparing last ys xs == LT = Just (ys,xs:yss)
      | otherwise                  = Just (xs,ys:yss)

ssort :: [String] -> [String]
ssort = unfoldr select where
  select []       = Nothing
  select [xs]     = Just (xs,[])
  select (xs:xss) =
    if comparing last min xs == LT
    then Just (min,takeWhile (/=min) xss ++ xs : tail (dropWhile (/=min) xss))
    else Just (xs,xss)
    where min = minimumBy (comparing last) xss

main :: IO ()
main = do
  getLine
  cs <- fmap words getLine
  let bs = unwords . bsort $ cs
  let ss = unwords . ssort $ cs
  putStrLn bs
  putStrLn "Stable"
  putStrLn ss
  putStrLn $ if bs == ss then "Stable" else "Not stable"

test :: IO ()
test = do
  print $ bsort ["H4","C9","S4","D2","C3"] == ["D2","C3","H4","S4","C9"]
  print $ ssort ["H4","C9","S4","D2","C3"] == ["D2","C3","S4","H4","C9"]
