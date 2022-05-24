# https://atcoder.jp/contests/dp/submissions/4653138
def f(a1,a2,a3,b1,b2,b3)
  return (b3-b2)*(a2-a1) >= (b2-b1)*(a3-a2)
end

n,c = gets.split.map(&:to_i)
h = gets.split.map(&:to_i)
dp = Array.new(n,0)
b = [0]
for i in 1..n-1
  while b.size > 1 && dp[b[0]]+(h[i]-h[b[0]])**2 > dp[b[1]]+(h[i]-h[b[1]])**2
    b.shift
  end
  dp[i] = dp[b[0]]+(h[i]-h[b[0]])**2+c
  while b.size > 1 && f(-2*h[b[-2]],-2*h[b[-1]],-2*h[i],dp[b[-2]]+h[b[-2]]**2,dp[b[-1]]+h[b[-1]]**2,dp[i]+h[i]**2)
    b.pop
  end
  b.push(i)
end
p dp[-1]
