{-
https://atcoder.jp/contests/agc032/submissions/4670971
-}
main :: IO ()
main = do
  _ <- getLine
  bs <- map read . words <$> getLine
  mapM_ print $ f bs []

maxIns :: [Int] -> Maybe Int
maxIns bs = fmap fst $ safeLast . filter ((==) <$> fst <*> snd) $ zip bs [1..]

safeLast :: [a] -> Maybe a
safeLast [] = Nothing
safeLast xs = Just (last xs)

rm :: [Int] -> Int -> [Int]
rm bs i = take (i-1) bs ++ drop i bs

f :: [Int] -> [Int] -> [Int]
f [] as = as
f bs as = case maxIns bs of
            Nothing -> [-1]
            Just i  -> f (rm bs i) (i:as)
