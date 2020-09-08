# # Largest palindrome product
# - [URL](https://projecteuler.net/problem=4)
# ## Problem 4
# A palindromic number reads the same both ways.
# The largest palindrome made from the product of two 2-digit numbers is 9009 = 91 × 99.
# Find the largest palindrome made from the product of two 3-digit numbers.
#
# 回文数は 2 通りの同じ読み方を持つ。
# 2 桁の数の積からなる最大の回文数は 9009 = 91 x 99 である。
# 3 桁の数の積からなる最大の回文数を求めよ。
function solve()
  max = 0
  for i in 100:999
    for j in i:999
      num = i * j
      num_str = string(num)
      len = length(num_str)
      half_len = (len / 2) |> floor |> Int32
      if len % 2 == 0
        before = num_str[1:half_len]
        after = reverse(num_str[half_len+1:len])
        if before == after && max < num
          max = num
        end
      else
        before = num_str[1:half_len+1]
        after = reverse(num_str[half_len+1:len])
        if before == after && max < num
          max = num
        end
      end
    end
  end
  println(max)
end

solve()
