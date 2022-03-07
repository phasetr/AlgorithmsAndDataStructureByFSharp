{-
https://atcoder.jp/contests/abc130/submissions/19753409
-}
main :: IO ()
main = interact $ solve . map read . words

solve :: (Show a, Fractional a, Eq a) => [a] -> String
solve [w,h,x,y] = show(w*h/2) ++
  if w==x*2 && h==y*2 then" 1"else" 0"
solve _ = error "not come here"
