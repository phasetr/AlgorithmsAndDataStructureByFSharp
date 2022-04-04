-- https://atcoder.jp/contests/abc061/submissions/15800217
import Data.List
main = interact
  $ show . f . map (map read . words) . lines

f([n,k]:l) = k % sort l;k%([a,b]:l)|b<k=(k-b)%l|0<1=a
