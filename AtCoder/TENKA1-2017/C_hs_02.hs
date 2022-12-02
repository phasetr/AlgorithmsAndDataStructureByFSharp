-- https://atcoder.jp/contests/tenka1-2017/submissions/14262074
main :: IO ()
main = do
  n <- readLn :: IO Int
  let (x,y,z) = head [(h,w,(h*w*n) `div` (4*h*w-w*n-h*n)) | h <- [1..3500], w <- [h..3500], (4*h*w-w*n-h*n) > 0, (h*w*n) `mod` (4*h*w-w*n-h*n) == 0]
  putStrLn $ show x ++ " " ++ show y ++ " " ++ show z
