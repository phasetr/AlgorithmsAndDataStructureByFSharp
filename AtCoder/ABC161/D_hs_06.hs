-- https://atcoder.jp/contests/abc161/submissions/11538255
main :: IO ()
main = do
  li <- getLine
  let k = read li
  let ans = compute k
  print ans

{-
n桁のルンルン数の列に対して、
それらを10倍して、元の1の位を-1,+-0,+1した数を
加えたものがn+1桁のルンルン数になる。
ただし、0-1や9+1は却下する。
-}

lunluns :: [Int]
lunluns = [1..9] ++
  [ x*10+e
  | x <- lunluns
  , let d = mod x 10
  , e <- [d-1,d,d+1]
  , 0 <= e, e <= 9
  ]

compute :: Int -> Int
compute k = lunluns !! pred k
