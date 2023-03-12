-- https://atcoder.jp/contests/tessoku-book/submissions/35953968
main :: IO ()
main = do
  n <- readLn
  co <- getContents
  let sts = map words $ lines co
  let ans = tbc08 n sts
  putStrLn ans

tbc08 :: Int -> [[String]] -> String
tbc08 n sts
  | not $ null rank1s = head $ head rank1s
  | singleton cands = head cands
  | otherwise = "Can't Solve"
  where
    rank1s = filter (("1" ==) . (!! 1)) sts
    cands =
      [ abcd
      | a <- digits, b <- digits, c <- digits, d <- digits
      , let abcd = [a,b,c,d]
      , all (valid abcd) sts
      ]

valid :: [Char] -> [[Char]] -> Bool
valid abcd (s:t:_)
  | t == "3" = cnt >  1
  | t == "2" = cnt == 1
  where
    cnt = length $ filter id $ zipWith (/=) abcd s

digits :: [Char]
digits = ['0'..'9']

singleton :: [a] -> Bool
singleton [_] = True
singleton _ = False

-- 同じ位置が異なるものの数を数えて、1なら2等、それ以上なら3等
