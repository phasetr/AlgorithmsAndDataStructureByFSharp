# # Largest prime factor
# - [URL](https://projecteuler.net/problem=3)
# ## Problem 3
# The prime factors of 13195 are 5, 7, 13 and 29.
# What is the largest prime factor of the number 600851475143?
#
# 13195 の素因数は 5, 7, 13, 29 である。
# 600851475143 の最大の素因数は何か？
function solve(n)
  orig_n = n
  sqrt_n = n |> sqrt |> ceil |> Int64

  i = 2
  maxnum = 1
  while i < sqrt_n
    if n % i == 0
      n = n / i
      maxnum = i
    else
      i = i + 1
    end
  end
  if n != 1
    maxnum = orig_n
  end
  println(maxnum)
end

target = 600851475143
solve(target)
