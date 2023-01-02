-- https://atcoder.jp/contests/tessoku-book/submissions/35376312
tba32 :: Int -> Int -> Int -> Bool
tba32 n a b = wf !! (b + n)
  where wf = replicate b True ++ replicate a False ++ zipWith nand (drop a wf) (drop b wf)

nand :: Bool -> Bool -> Bool
nand a b = not (a && b)

main :: IO ()
main = do
  [n,a,b] <- getLnInts
  let ans = tba32 n a b
  putStrLn $ if ans then "First" else "Second"

getLnInts :: IO [Int]
getLnInts = map read . words <$> getLine
