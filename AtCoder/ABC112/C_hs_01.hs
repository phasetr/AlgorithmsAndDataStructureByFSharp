-- https://atcoder.jp/contests/abc112/submissions/9848391
main :: IO ()
main = do
 getLine
 xyh <- map (map read . words) . lines <$> getContents
 let [sx,sy,sh] = head $ filter ((>0) . (!!2)) xyh
 putStrLn $unwords $ map show $ head [[x,y,h] | x <- [0..100], y <- [0..100],
                                      let h = sh + abs(sx-x) + abs(sy-y), ok x y h xyh]
ok :: (Ord t, Num t) => t -> t -> t -> [[t]] -> Bool
ok sx sy sh [] = True
ok sx sy sh ([x,y,h]:xyh)
 | max (sh - abs(sx-x) - abs(sy-y)) 0 == h = ok sx sy sh xyh
 | otherwise=False
ok _ _ _ _ = error "not come here"
