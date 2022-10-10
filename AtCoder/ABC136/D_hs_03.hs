-- https://atcoder.jp/contests/abc136/submissions/17413377
import Data.List ( group )

solve :: [Int] -> [Int]
solve [] = []
solve (a:b:s) = as ++ [a'] ++ [b'] ++ bs ++ solve s where
  as = replicate (a-1) 0
  bs = replicate (b-1) 0
  a' = div (a+1) 2 + div b 2
  b' = div a 2 + div (b+1) 2
solve _ = error "not come here"

main :: IO ()
main = do
  s <- getLine
  let ss = map length $ group s
  putStrLn $ unwords $ map show (solve ss)

test :: IO ()
test = do
  print (group "RRLRL")
  print (f "RRLRL" == [0,1,2,1,1])
  print (group "RRLLLLRLRRLL")
  print (map length $ group "RRLLLLRLRRLL")
  print (f "RRLLLLRLRRLL" == [0,3,3,0,0,0,1,1,0,2,2,0])
  print (f "RRRLLRLLRRRLLLLL" == [0,0,3,2,0,2,1,0,0,0,4,4,0,0,0,0])
  where f = solve . map length . (group ::String -> [String])
