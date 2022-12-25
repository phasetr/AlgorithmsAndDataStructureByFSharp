-- https://atcoder.jp/contests/code-festival-2017-quala/submissions/3137529
main :: IO ()
main = do
  [h,w] <- map read . words <$> getLine :: IO [Int]
  s <- getContents
  let count = [length $ filter (==c) s | c <- ['a'..'z']]
  putStrLn $ if solve h w count then "Yes" else "No"
  where
    solve h w count
      | even h && even w = all ((==0) . (`mod`4)) count
      | odd h && odd w =
        (length . filter ((==2) . (`mod`4))) count <= (h `div` 2 + w `div` 2) &&
        (length . filter odd) count == 1
      | odd h = all even count && (length . filter ((==2) . (`mod`4))) count <= w `div` 2
      | odd w = all even count && (length . filter ((==2) . (`mod`4))) count <= h `div` 2
